# Serial Monitor
Serial Monitor is a versatile tool designed for multi-channel/multi-serial device control and communication. Whether you're working with binary data, plain text, C commands, or Modbus RTU/ASCII, this Serial Monitor empowers you to send, receive, and visualize data seamlessly. Additionally, it offers step commands for precise control and the ability to save configurations and step programs to files.

![image](https://github.com/user-attachments/assets/b6fe7369-bf6b-4a6d-addf-0730bb120e66)


## Features

- **Multi-Channel/Multi-Serial Device Control**: Effortlessly manage multiple serial devices or channels from a single interface, streamlining your communication tasks.
  
![image](https://github.com/julihirn/Serial-Monitor/assets/94691568/a50e4828-6dda-436c-9e33-3c400ab7d34c)


- **Data Reception and Display Formats**:
  - **Binary/Hexadecimal Stream**: Receive and display data in binary or hexadecimal format, enabling you to visualize raw data as it comes in.
  - **Plain Text**: Interpret incoming data as plain text, perfect for human-readable messages and information.
  - **C Command**: Process incoming data as C commands.
  - **Modbus RTU/ASCII**: Seamlessly interact with devices using the Modbus RTU/ASCII protocol.
  - **Numerical Formats**: Receive raw binary, octal, decimal and hexadecimal values.

- **Data Transmission Formats**:
  - **Plain Text**: Easily send plain text messages to your serial devices.
  - **C Command**: Send C commands to your devices.
  - **Modbus RTU/ASCII**: Transmit data using the Modbus RTU/ASCII protocol, ensuring compatibility with a wide range of industrial devices.
  - **Numerical Formats**: Send raw binary, octal, decimal and hexadecimal values.

- **Step Program**: Take precise control over your serial communication by utilizing step commands. This feature allows you to automate complex or repetitive actions at the click of a button. Programs can print, send (text, text files) and control the flow of operations.
  
![image](https://github.com/julihirn/Serial-Monitor/assets/94691568/d05bd3ec-9ba7-418e-b24f-6063fc3be267)

- **Configuration and Step Program Saving**: Serial Monitor allows you to save your configurations and step programs to files. This ensures that you can quickly replicate setups and program sequences without manual reconfiguration.

- **Configurable Keypad**: Design and set keypad buttons for quick prototyping of serial devices.

![image](https://github.com/julihirn/Serial-Monitor/assets/94691568/2f19bfc0-ef50-4224-a30e-0e60956f641c)

- **Modbus Coil and Register Editor/Monitor**: Edit, view and monitor your Modbus devices with the Modbus Registers editor.
  
![image](https://github.com/julihirn/Serial-Monitor/assets/94691568/4d51eadb-61ad-497e-8401-d16f86dea8a2)

- **Modbus Query Editor**: Interact with your Modbus devices with the Modbus Query Language editor.
![image](https://github.com/julihirn/Serial-Monitor/assets/94691568/1a4fca1a-1b74-452c-b721-d37798b5854e)

## System Requirements
* Windows 10 or higher.
* Requires .Net 8 to be installed.
## Project Dependencies
Requires: [ODModules](https://github.com/julihirn/ODModules), [ODHandles](https://github.com/julihirn/ODHandlers).

## Future Work
This project is still a bit of a work in progress, I am actively working on adding new features.

Current Development Roadmap:
* Modbus register editor patch up
* Undo/redo and editing history
* Graphing

## Contributing

Contributions to this application are welcome! If you find bugs, want to add features, or improve the documentation, feel free to open issues and pull requests in this repository.

## License

This project is licensed under the [MIT License](LICENSE), which means you're free to use, modify, and distribute it as per the terms of the license.

