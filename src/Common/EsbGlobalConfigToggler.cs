// BizTalk ESB Toolkit Enterprise Library machine.config Toggler
// Copyright (C) 2013-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace ESBToolkitEntLibMachineConfigToggler.Common
{
    public class EsbGlobalConfigToggler
    {
        const string commentedSectionRegex = @"<!--\s*(<section name=""enterpriseLibrary.ConfigurationSource""[\w,=,"",',,\.,\s]+/>)\s*-->";
        const string commentedSourceRegex = @"<!--\s*(<enterpriseLibrary.ConfigurationSource[\w\W]*</enterpriseLibrary.ConfigurationSource>)\s*-->";
        const string uncommentedSectionRegex = @"(<section name=""enterpriseLibrary.ConfigurationSource""[\w,=,"",',,\.,\s]+/>)";
        const string uncommentedSourceRegex = @"(<enterpriseLibrary.ConfigurationSource[\w\W]*</enterpriseLibrary.ConfigurationSource>)";

        public event EventHandler<ToggleStatusEventArgs> ToggleMessage;

        public void Toggle()
        {
            List<string> machineConfigPaths = GetMachineConfigPaths();

            foreach (string machineConfigPath in machineConfigPaths)
            {
                OnStatusChanged("Processing '" + machineConfigPath + "'...");

                string xml = File.ReadAllText(machineConfigPath);

                bool foundCommentedSection = false;
                bool foundCommentedSource = false;
                bool foundUncommented = false;

                Match commentedSectionMatch = Regex.Match(xml, commentedSectionRegex);

                if (commentedSectionMatch.Success)
                {
                    foundCommentedSection = true;
                }

                Match commentedSourceMatch = Regex.Match(xml, commentedSourceRegex);

                if (commentedSourceMatch.Success)
                {
                    foundCommentedSource = true;
                }

                if (foundCommentedSection && !foundCommentedSource)
                {
                    xml = Regex.Replace(xml, commentedSectionRegex, commentedSectionMatch.Groups[1].Value);
                    OnStatusChanged("Found commented section and uncommented enterpriseLibrary.ConfigurationSource. Enabling...");
                }
                else if (!foundCommentedSection && foundCommentedSource)
                {
                    xml = Regex.Replace(xml, commentedSourceRegex, commentedSourceMatch.Groups[1].Value);
                    OnStatusChanged("Found uncommented section and commented enterpriseLibrary.ConfigurationSource. Enabling...");
                }
                else if (foundCommentedSection && foundCommentedSource)
                {
                    xml = Regex.Replace(xml, commentedSectionRegex, commentedSectionMatch.Groups[1].Value);
                    xml = Regex.Replace(xml, commentedSourceRegex, commentedSourceMatch.Groups[1].Value);
                    OnStatusChanged("Found commented section and commented enterpriseLibrary.ConfigurationSource. Enabling...");
                }
                else
                {
                    Match uncommentedSectionMatch = Regex.Match(xml, uncommentedSectionRegex);

                    if (uncommentedSectionMatch.Success)
                    {
                        foundUncommented = true;
                        xml = Regex.Replace(xml, uncommentedSectionRegex, "<!--" + uncommentedSectionMatch.Groups[1].Value + "-->");
                    }

                    Match uncommentedSourceMatch = Regex.Match(xml, uncommentedSourceRegex);

                    if (uncommentedSourceMatch.Success)
                    {
                        foundUncommented = true;
                        xml = Regex.Replace(xml, uncommentedSourceRegex, "<!--" + uncommentedSourceMatch.Groups[1].Value + "-->");
                    }

                    if (foundUncommented)
                    {
                        OnStatusChanged("Found uncommented section and uncommented enterpriseLibrary.ConfigurationSource. Disabling...");
                    }
                    else
                    {
                        OnStatusChanged("No changes required because no enterpriseLibrary.ConfigurationSource was found.");
                    }
                }

                if (foundCommentedSection || foundCommentedSource || foundUncommented)
                {
                    string machineConfigBackupPath = machineConfigPath + ".esbtoggle.bak";
                    if (File.Exists(machineConfigBackupPath))
                    {
                        File.Delete(machineConfigBackupPath);
                    }
                    File.Copy(machineConfigPath, machineConfigBackupPath, true);

                    OnStatusChanged("Saved machine.config changes.");
                    File.WriteAllText(machineConfigPath, xml);
                }

                OnStatusChanged(string.Empty);
            }
        }

        private List<string> GetMachineConfigPaths()
        {
            List<string> paths = new List<string>();

            paths.AddRange(
                GetMachineConfigPathsForVersion(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full",
                    "InstallPath",
                    @"config\machine.config"));

            paths.AddRange(
                GetMachineConfigPathsForVersion(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework",
                    "InstallRoot",
                    @"v2.0.50727\config\machine.config"));

            return paths;
        }

        private List<string> GetMachineConfigPathsForVersion(string regPath, string regKey, string machineConfigSubPath)
        {
            List<string> paths = new List<string>();

            bool isWin64 = Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("windir"), "syswow64"));

            string netInstallPath = Registry.GetValue(regPath, regKey, null) as string;

            if (!string.IsNullOrEmpty(netInstallPath))
            {
                string netMachineConfigPath = Path.Combine(netInstallPath, machineConfigSubPath);

                paths.Add(netMachineConfigPath);

                if (isWin64)
                {
                    netMachineConfigPath = netMachineConfigPath.Replace(@"Framework\", @"Framework64\");
                    paths.Add(netMachineConfigPath);
                }
            }

            return paths;
        }

        private void OnStatusChanged(string message)
        {
            if (ToggleMessage != null)
            {
                ToggleMessage(this, new ToggleStatusEventArgs(message));
            }
        }
    }
}
