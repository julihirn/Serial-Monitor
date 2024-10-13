using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public static class StepEnumerations {
        public enum StepState {
            Stopped = 0x00,
            Paused = 0x01,
            Running = 0x02
        }
        public enum StepKeyWordType {
            Normal = 0x00,
            ControlFlow = 0x01,
            ReturnsAndCalls = 0x02,
            VariableDeclaration = 0x03
        }
        public enum StepExecutable {
            NoOperation =       0x000000,
            GoTo =              0x010080,
            GoToLine =          0x010042,
            Call =              0x010041,
            Label =             0x010040,
            Delay =             0x010100,
            End =               0x010200,
            SetProgram =        0x010001,
            If =                0x010081,
            //ElseIf            = 0x010082,
            Else              = 0x010083,
            EndIf =             0x01FFFF,
            //For               = 0x011000,
            //Next =              0x011001,
            SwitchSender    =   0x020001,
            Open =              0x020020,
            OpenChannel       = 0x020021,
            Close =             0x020040,
            CloseChannel      = 0x020041,
            SelectChannel =     0x020060,
            SendVariable      = 0x030001,
            SendByte =          0x030002,
            SendString =        0x030004,
            SendLine =          0x030008,
            SendText =          0x030010,
            Print =             0x040040,
            PrintVariable =     0x040060,
            PrintText =         0x040061,
            Clear =             0x040080,
            DeclareVariable =   0x050001,
            IncrementVariable = 0x050002,
            DecrementVariable = 0x050003,
            EvaluateExpression =    0x05F001,
            PushArrayValue = 0x1005F001,
            RemoveFirstArrayItem = 0x1005FC04,
            CopyText = 0x1005FE01,
            CopyVariable     = 0x1005FF01,
            ReplaceInVariable= 0x1005FF10,
            ///SelectChannel = 0x050400,
            //NewChannel = 0x050800,
            //DeleteChannel = 0x051000,
            //JumpOnPress = 0x060001,
            MousePosition =     0x090001,
            MouseLeftClick =    0x090002,
            // MouseMiddleClick =    0x090003,
            // MouseRightClick =    0x090004,
            MousePositionOffset =    0x090005,
            SendKeys =          0x090010,
            //WaitUntil         = 0x101E001,
            WaitUntilReceived = 0x101E002,
            RaiseEvent =       0x100F0001,
            WaitUntilRaiseEvent = 0x100F0010
            //0x1005FC04,
            //ResetChannelCounter = 0x10050400
        }
    }
}
