// BizTalk ESB Toolkit Enterprise Library machine.config Toggler
// Copyright (C) 2013-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBToolkitEntLibMachineConfigToggler.Common;

namespace ESBToolkitEntLibMachineConfigToggler.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            statusTextBox.Clear();

            EsbGlobalConfigToggler toggler = new EsbGlobalConfigToggler();
            toggler.ToggleMessage += OnToggleMessage;
            toggler.Toggle();
        }

        private void OnToggleMessage(object sender, ToggleStatusEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<ToggleStatusEventArgs>(OnToggleMessage), sender, e);
            }

            statusTextBox.AppendText(e.Message + Environment.NewLine);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}
