// BizTalk ESB Toolkit Enterprise Library machine.config Toggler
// Copyright (C) 2013-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESBToolkitEntLibMachineConfigToggler.Common
{
    public class ToggleStatusEventArgs : EventArgs
    {
        public string Message { get; private set; }

        internal ToggleStatusEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
