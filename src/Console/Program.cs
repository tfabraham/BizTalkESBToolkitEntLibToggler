// BizTalk ESB Toolkit Enterprise Library machine.config Toggler
// Copyright (C) 2013-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.Text;
using ESBToolkitEntLibMachineConfigToggler.Common;
using System.Reflection;

namespace ESBToolkitEntLibMachineConfigToggler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(AssemblyTitle + " " + AssemblyVersion);
            System.Console.WriteLine();

            EsbGlobalConfigToggler toggler = new EsbGlobalConfigToggler();
            toggler.ToggleMessage += OnToggleMessage;
            toggler.Toggle();
        }

        private static void OnToggleMessage(object sender, ToggleStatusEventArgs e)
        {
            System.Console.WriteLine(e.Message);
        }

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
