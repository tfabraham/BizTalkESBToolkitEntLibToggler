# BizTalk ESB Toolkit Enterprise Library machine.config Toggler
An on/off switch for the enterpriseLibrary.ConfigurationSource changes that the BizTalk ESB Toolkit makes to machine.config.

The BizTalk ESB Toolkit adds an enterpriseLibrary.ConfigurationSource element to all machine.config's that redirects the global Enterprise Library configuration to esb.config or SSO. This is extremely inconvenient when you switch back and forth between development of BizTalk apps and other .NET apps that use Enterprise Library.

After enough times of opening Notepad in Administrator mode and editing four machine.config files by hand, I decided to create and share a tool that eliminates that extra work. The BizTalk ESB Toolkit EntLib machine.config Toggler instantly comments out or uncomments the enterpriseLibrary.ConfigurationSource element in all machine.config files (.NET 2.0/4.0 and x86/x64).

It includes a WinForms UI and a command-line app.

## License

Copyright (c) Thomas F. Abraham. All rights reserved.

Licensed under the [MIT](LICENSE.txt) License.
