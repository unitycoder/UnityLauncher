using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityLauncher
{
    public partial class Form1 : Form
    {
        private string pathArg = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: setup window to scan for unity installations (give parent folder)

            // check if any arguments (that means, it should parse something)
            string[] args = Environment.GetCommandLineArgs();

            // sample path
            // "D:\download\Swarm-master(1)\Swarm-master"


            if (args != null && args.Length > 1)
            {
                pathArg = args[1];

                Console.WriteLine("\nPATH: " + pathArg);
                Console.WriteLine("");
            }
            else
            {

                Console.WriteLine("Running in setup-mode");
                return;
            }

            // check if path is unity project folder
            if (Directory.Exists(pathArg) == true)
            {
                // validate folder
                if (Directory.Exists(Path.Combine(pathArg, "Assets")))
                {
                    // this looks like unity project folder, check version
                    if (Directory.Exists(Path.Combine(pathArg, "ProjectSettings")))
                    {
                        var versionPath = Path.Combine(pathArg, "ProjectSettings", "ProjectVersion.txt");
                        if (File.Exists(versionPath))
                        {
                            var version = GetProjectVersion(versionPath);
                            Console.WriteLine("Detected project version: " + version);

                            bool installed = CheckInstalled("Unity " + version);
                            if (installed == true)
                            {
                                // TODO: open?
                                Console.WriteLine("Opening unity version " + version);
                            }
                            else
                            {
                                throw new Exception("Unity version " + version + " is not installed!");
                            }
                        }
                        else
                        {
                            throw new FileNotFoundException("Cannot find ProjectVersion.txt for :" + pathArg);
                        }
                    }
                    else
                    {
                        throw new DirectoryNotFoundException("Cannot find ProjectSettings/ at :" + pathArg);
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException("No Assets folder founded in: " + pathArg);
                }
            }
            else // given path doesnt exists, strange
            {
                throw new DirectoryNotFoundException("Invalid Path:" + pathArg);
            }

            // check if unity with that version is installed


            // if not installed, offer download

        }


        // read and parse project settings file
        string GetProjectVersion(string path)
        {
            var v = "unknown";
            var d = File.ReadAllLines(path);
            if (d != null && d.Length > 0)
            {
                var dd = d[0];
                // check first line
                if (dd.Contains("m_EditorVersion"))
                {
                    var t = dd.Split(new string[] { "m_EditorVersion: " }, StringSplitOptions.None);
                    if (t != null && t.Length > 0)
                    {
                        v = t[1].Trim();
                    }
                    else
                    {
                        throw new InvalidDataException("invalid version data:" + d);
                    }
                }
                else
                {
                    throw new InvalidDataException("Cannot find m_EditorVersion:" + dd);
                }
            }
            else
            {
                throw new InvalidDataException("invalid projectversion data:" + d.ToString());
            }
            return v;
        }


        // check installed apps from uninstall list in registry https://stackoverflow.com/a/16392220/5452781
        // but unity doesnt write there
        public static bool CheckInstalled(string appName)
        {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(appName))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(appName))
                    {
                        return true;
                    }
                }
                key.Close();
            }
            return false;
        }

        // set basefolder of all unity installations
        private void btn_setinstallfolder_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> unityList = new Dictionary<string, string>();

            var d = folderBrowserDialog1.ShowDialog();
            var root = folderBrowserDialog1.SelectedPath;

            if (String.IsNullOrWhiteSpace(root) == false)
            {
                // parse all folders here, and search for unity editor files
                var directories = Directory.GetDirectories(root);
                for (int i = 0, length = directories.Length; i < length; i++)
                {
                    var uninstallExe = Path.Combine(directories[i], "Editor", "Uninstall.exe");
                    if (File.Exists(uninstallExe))
                    {
                        var unityExe = Path.Combine(directories[i], "Editor", "Unity.exe");
                        var unityVersion = GetFileVersion(uninstallExe);
                        // TODO: check if exists, warn
                        unityList.Add(unityVersion, unityExe);
                        lst_unitys.Items.Add(unityVersion + " (" + unityExe + ")");
                    } // have uninstaller
                } // got folders
            } // didnt select anything

            lst_unitys.Sorted = true;

        }

        private string GetFileVersion(string path)
        {
            // todo check path
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.ProductName.Replace("(64-bit)", "").Trim();
        }

    }
}
