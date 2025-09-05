using Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Serial {
    internal static class DeviceHandler {
        // Known VIDs
        private const string VID_FTDI = "VID_0403";
        private const string VID_CP210x = "VID_10C4";
        private const string VID_CH340 = "VID_1A86";
        private const string VID_PL2303 = "VID_067B";
        private const string VID_MICROCHIP = "VID_04D8"; // MCP22xx etc.
        #region Libary Loading
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);
        #endregion
        public static void SetLowLatency(string comPort, byte latencyMs = 1) {
            string? deviceId = GetDeviceIdFromComPort(comPort);
            if (deviceId == null) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_TUNE", $"No USB serial device found for {comPort}.");
                return;
            }
            if (deviceId.Contains(VID_FTDI, StringComparison.OrdinalIgnoreCase)) {
                SetFTDILatency(comPort, latencyMs);
            }
            else if (deviceId.Contains(VID_CP210x, StringComparison.OrdinalIgnoreCase)) {
                SetCP210xLatency(comPort, latencyMs);
            }
            else if (deviceId.Contains(VID_CH340, StringComparison.OrdinalIgnoreCase)) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_TUNE", $"{comPort} is CH340/CH341 → latency tuning not supported.");
            }
            else if (deviceId.Contains(VID_PL2303, StringComparison.OrdinalIgnoreCase)) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_TUNE", $"{comPort} is Prolific PL2303 → latency tuning not supported.");
            }
            else if (deviceId.Contains(VID_MICROCHIP, StringComparison.OrdinalIgnoreCase)) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_TUNE", $"{comPort} is Microchip MCP22xx → no latency tuning available.");
            }
            else {
                SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_TUNE", $"{comPort} device {deviceId} not in supported list.");
            }
        }

        #region FTDI Chipset Support
        private delegate uint FT_OpenExDelegate(string deviceIdentifier, uint flags, out IntPtr handle);
        private delegate uint FT_CloseDelegate(IntPtr handle);
        private delegate uint FT_SetLatencyTimerDelegate(IntPtr handle, byte timer);
        private const uint FT_OPEN_BY_SERIAL_NUMBER = 1;
        private static void SetFTDILatency(string comPort, byte latencyMs) {
            string? serial = ExtractSerialFromDeviceId(comPort, VID_FTDI);
            if (serial == null) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_FTDI_TUNE", $"Could not resolve FTDI serial for {comPort}.");
                return;
            }
            IntPtr lib = LoadLibrary("FTD2XX.dll");
            if (lib == IntPtr.Zero) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_FTDI_TUNE", "FTD2XX.dll not found. Skipping FTDI latency tuning.");
                return;
            }
            try {
                var openEx = Marshal.GetDelegateForFunctionPointer<FT_OpenExDelegate>(GetProcAddress(lib, "FT_OpenEx"));
                var close = Marshal.GetDelegateForFunctionPointer<FT_CloseDelegate>(GetProcAddress(lib, "FT_Close"));
                var setLat = Marshal.GetDelegateForFunctionPointer<FT_SetLatencyTimerDelegate>(GetProcAddress(lib, "FT_SetLatencyTimer"));
                if (openEx(serial, FT_OPEN_BY_SERIAL_NUMBER, out IntPtr handle) == 0) {
                    if (setLat(handle, latencyMs) == 0) {
                        SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_FTDI_TUNE", $"FTDI {comPort} latency set to {latencyMs} ms.");
                    }
                    else {
                        SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_FTDI_TUNE", "Could not set latency for FTDI device.");
                    }
                    close(handle);
                }
                else {
                    SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_FTDI_TUNE", $"Could not open FTDI device for {comPort} by serial.");
                }
            }
            catch (Exception ex) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Error, "COM_DRV_FTDI_TUNE", "Failed to adjust FTDI latency: " + ex.Message);
            }
            finally {
                FreeLibrary(lib);
            }
        }
        #endregion
        #region CP210x Chipset Support
        private enum CP210x_STATUS : uint {
            CP210x_SUCCESS = 0x00,
            CP210x_DEVICE_NOT_FOUND = 0xFF
        }
        private delegate CP210x_STATUS CP210x_OpenDelegate(uint deviceIndex, out IntPtr handle);
        private delegate CP210x_STATUS CP210x_CloseDelegate(IntPtr handle);
        private delegate CP210x_STATUS CP210x_SetLatencyTimerDelegate(IntPtr handle, byte latency);
        private static void SetCP210xLatency(string comPort, byte latencyMs) {
            IntPtr lib = LoadLibrary("CP210xManufacturing.dll");
            if (lib == IntPtr.Zero) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_CP210x_TUNE", "CP210xManufacturing.dll not found. Skipping CP210x latency tuning.");
                return;
            }
            try {
                var open = Marshal.GetDelegateForFunctionPointer<CP210x_OpenDelegate>(GetProcAddress(lib, "CP210x_Open"));
                var close = Marshal.GetDelegateForFunctionPointer<CP210x_CloseDelegate>(GetProcAddress(lib, "CP210x_Close"));
                var setLat = Marshal.GetDelegateForFunctionPointer<CP210x_SetLatencyTimerDelegate>(GetProcAddress(lib, "CP210x_SetLatencyTimer"));
                if (open(0, out IntPtr handle) == CP210x_STATUS.CP210x_SUCCESS) {
                    if (setLat(handle, latencyMs) == CP210x_STATUS.CP210x_SUCCESS){
                        SystemManager.InvokeErrorMessage(ErrorType.M_Notification, "COM_DRV_CP210x_TUNE", $"CP210x {comPort} latency set to {latencyMs} ms.");
                    }
                    else{
                        SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_CP210x_TUNE", "CP210x_SetLatencyTimer failed.");
                    }
                    close(handle);
                }
                else {
                    SystemManager.InvokeErrorMessage(ErrorType.M_Warning, "COM_DRV_CP210x_TUNE", $"Could not open CP210x device for {comPort}.");
                }
            }
            catch (Exception ex) {
                SystemManager.InvokeErrorMessage(ErrorType.M_Error, "COM_DRV_CP210x_TUNE", "CP210x latency tuning failed: " + ex.Message);
            }
            finally {
                FreeLibrary(lib);
            }
        }
        #endregion 
        #region Support
        private static string? GetDeviceIdFromComPort(string comPort) {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'");
            foreach (var device in searcher.Get()) {
                string name = device["Name"]?.ToString() ?? "";
                string deviceId = device["DeviceID"]?.ToString() ?? "";
                if (name.Contains(comPort, StringComparison.OrdinalIgnoreCase))
                    return deviceId;
            }
            return null;
        }
        private static string? ExtractSerialFromDeviceId(string comPort, string vid) {
            string? devId = GetDeviceIdFromComPort(comPort);
            if (devId == null || !devId.Contains(vid)) return null;
            // Example: USB\VID_0403&PID_6001\A6001234
            string[] parts = devId.Split('\\');
            return parts.Length >= 3 ? parts[2] : null;
        }
        #endregion 
    }
}
