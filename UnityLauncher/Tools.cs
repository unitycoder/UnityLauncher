using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UnityLauncherTools
{
    public static class Tools
    {
        /// <summary>
        /// open url with default browser
        /// </summary>
        /// <param name="url"></param>
        public static void OpenURL(string url)
        {
            Process.Start(url);
        }

        /// <summary>
        /// reads .git/HEAD file from the project to get current branch name
        /// </summary>
        /// <param name="projectPath"></param>
        /// <returns></returns>
        public static string ReadGitBranchInfo(string projectPath)
        {
            string results = null;
            DirectoryInfo gitDirectory = FindDir(".git", projectPath);
            if (gitDirectory != null)
            {
                string branchFile = Path.Combine(gitDirectory.FullName, "HEAD");
                if (File.Exists(branchFile))
                {
                    results = File.ReadAllText(branchFile);
                    // get branch only
                    int pos = results.LastIndexOf("/") + 1;
                    results = results.Substring(pos, results.Length - pos);
                }
            }
            return results;
        }

        /// <summary>
        /// Searches for a directory beginning with "startPath".
        /// If the directory is not found, then parent folders are searched until
        /// either it is found or the root folder has been reached.
        /// Null is returned if the directory was not found.
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="startPath"></param>
        /// <returns></returns>
        public static DirectoryInfo FindDir(string dirName, string startPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(startPath, dirName));
            while (!dirInfo.Exists)
            {
                if (dirInfo.Parent.Parent == null)
                {
                    return null;
                }
                dirInfo = new DirectoryInfo(Path.Combine(dirInfo.Parent.Parent.FullName, dirName));
            }
            return dirInfo;
        }

        /// <summary>
        /// returns last-write-time for a file or folder
        /// </summary>
        /// <param name="path">full path to file or folder</param>
        /// <returns></returns>
        public static DateTime? GetLastModifiedTime(string path)
        {
            if (File.Exists(path) == true || Directory.Exists(path) == true)
            {
                DateTime modification = File.GetLastWriteTime(path);
                return modification;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// reads LauncherArguments.txt file from ProjectSettings-folder
        /// </summary>
        /// <param name="projectPath">full project root path</param>
        /// <param name="launcherArgumentsFile">default filename is "LauncherArguments.txt"</param>
        /// <returns></returns>
        public static string ReadCustomLaunchArguments(string projectPath, string launcherArgumentsFile)
        {
            string results = null;
            string argumentsFile = Path.Combine(projectPath, "ProjectSettings", launcherArgumentsFile);
            if (File.Exists(argumentsFile) == true)
            {
                results = File.ReadAllText(argumentsFile);
            }
            return results;
        }

        /// <summary>
        /// tries to find next higher version
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="allAvailable"></param>
        /// <returns></returns>
        public static string FindNearestVersion(string currentVersion, List<string> allAvailable)
        {
            if (currentVersion.Contains("2019"))
            {
                return FindNearestVersionFromSimilarVersions(currentVersion, allAvailable.Where(x => x.Contains("2019")));
            }
            if (currentVersion.Contains("2018"))
            {
                return FindNearestVersionFromSimilarVersions(currentVersion, allAvailable.Where(x => x.Contains("2018")));
            }
            if (currentVersion.Contains("2017"))
            {
                return FindNearestVersionFromSimilarVersions(currentVersion, allAvailable.Where(x => x.Contains("2017")));
            }
            return FindNearestVersionFromSimilarVersions(currentVersion, allAvailable.Where(x => !x.Contains("2017")));
        }

        private static string FindNearestVersionFromSimilarVersions(string version, IEnumerable<string> allAvailable)
        {
            Dictionary<string, string> stripped = new Dictionary<string, string>();
            var enumerable = allAvailable as string[] ?? allAvailable.ToArray();

            foreach (var t in enumerable)
            {
                stripped.Add(new Regex("[a-zA-z]").Replace(t, "."), t);
            }

            var comparableVersion = new Regex("[a-zA-z]").Replace(version, ".");
            if (!stripped.ContainsKey(comparableVersion))
            {
                stripped.Add(comparableVersion, version);
            }

            var comparables = stripped.Keys.OrderBy(x => x).ToList();
            var actualIndex = comparables.IndexOf(comparableVersion);

            if (actualIndex < stripped.Count - 1) return stripped[comparables[actualIndex + 1]];
            return null;
        }

        /// <summary>
        /// opens release notes url in default browser
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool OpenReleaseNotes(string version)
        {
            bool result = false;
            var url = GetUnityReleaseURL(version);
            if (string.IsNullOrEmpty(url) == false)
            {
                Process.Start(url);
                result = true;
            }
            else
            {
            }
            return result;
        }

        /// <summary>
        /// returns release page URL to given version
        /// NOTE: doesnt parse alpha versions, since they are not visible
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string GetUnityReleaseURL(string version)
        {
            string url = "";


            if (version.Contains("f")) // archived
            {
                // remove f#
                version = Regex.Replace(version, @"f.", "", RegexOptions.IgnoreCase);

                string padding = "unity-";
                string whatsnew = "whats-new";

                if (version.Contains("5.6")) padding = "";
                if (version.Contains("2017.1")) whatsnew = "whatsnew";
                if (version.Contains("2018.2")) whatsnew = "whatsnew";
                if (version.Contains("2018.3")) padding = "";
                if (version.Contains("2018.1")) whatsnew = "whatsnew"; // doesnt work
                if (version.Contains("2017.4.")) padding = ""; //  doesnt work for all versions
                if (version.Contains("2018.4.")) padding = "";
                if (version.Contains("2019")) padding = "";
                url = "https://unity3d.com/unity/" + whatsnew + "/" + padding + version;
            }
            else
            if (version.Contains("p")) // patch version
            {
                url = "https://unity3d.com/unity/qa/patch-releases/" + version;
            }
            else
            if (version.Contains("b")) // beta version
            {
                url = "https://unity3d.com/unity/beta/" + version;
            }
            else
            if (version.Contains("a")) // alpha version
            {
                url = "https://unity3d.com/unity/alpha/" + version;
            }

            return url;
        }

        /// <summary>
        /// uninstall context menu item from registry
        /// </summary>
        /// <param name="contextRegRoot"></param>
        public static void RemoveContextMenuRegistry(string contextRegRoot)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(contextRegRoot, true);
            if (key != null)
            {
                var appName = "UnityLauncher";
                RegistryKey appKey = Registry.CurrentUser.OpenSubKey(contextRegRoot + "\\" + appName, false);
                if (appKey != null)
                {
                    key.DeleteSubKeyTree(appName);
                    //SetStatus("Removed context menu registry items");
                }
                else
                {
                    //SetStatus("Nothing to uninstall..");
                }
            }
            else
            {
                //SetStatus("Error> Cannot find registry key: " + contextRegRoot);
            }
        }

        /// <summary>
        /// install context menu item to registry
        /// </summary>
        /// <param name="contextRegRoot"></param>
        public static void AddContextMenuRegistry(string contextRegRoot)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(contextRegRoot, true);

            // add folder if missing
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\Directory\Background\Shell");
            }

            if (key != null)
            {
                var appName = "UnityLauncher";
                key.CreateSubKey(appName);

                key = key.OpenSubKey(appName, true);
                key.SetValue("", "Open with UnityLauncher");
                key.SetValue("Icon", "\"" + Application.ExecutablePath + "\"");

                key.CreateSubKey("command");
                key = key.OpenSubKey("command", true);
                var executeString = "\"" + Application.ExecutablePath + "\"";
                executeString += " -projectPath \"%V\"";
                key.SetValue("", executeString);
            }
            else
            {
                Console.WriteLine("Error> Cannot find registry key: " + contextRegRoot);
            }
        }


        /// <summary>
        /// parse project version from ProjectSettings/ data
        /// </summary>
        /// <param name="path">project base path</param>
        /// <returns></returns>
        public static string GetProjectVersion(string path)
        {
            var version = "";

            if (File.Exists(Path.Combine(path, "ProjectVersionOverride.txt")))
            {
                version = File.ReadAllText(Path.Combine(path, "ProjectVersionOverride.txt"));
            }
            else if (Directory.Exists(Path.Combine(path, "ProjectSettings")))
            {
                var versionPath = Path.Combine(path, "ProjectSettings", "ProjectVersion.txt");
                if (File.Exists(versionPath) == true) // 5.x and later
                {
                    var data = File.ReadAllLines(versionPath);

                    if (data != null && data.Length > 0)
                    {
                        var dd = data[0];
                        // check first line
                        if (dd.Contains("m_EditorVersion"))
                        {
                            var t = dd.Split(new string[] { "m_EditorVersion: " }, StringSplitOptions.None);
                            if (t != null && t.Length > 0)
                            {
                                version = t[1].Trim();
                            }
                            else
                            {
                                throw new InvalidDataException("invalid version data:" + data);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot find m_EditorVersion in '" + versionPath + "'.\n\nFile Content:\n" + string.Join("\n", data).ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid projectversion data found in '" + versionPath + "'.\n\nFile Content:\n" + string.Join("\n", data).ToString());
                    }
                }
                else // maybe its 4.x
                {
                    versionPath = Path.Combine(path, "ProjectSettings", "ProjectSettings.asset");
                    if (File.Exists(versionPath) == true)
                    {
                        // first try if its ascii format
                        var data = File.ReadAllLines(versionPath);
                        if (data != null && data.Length > 0 && data[0].IndexOf("YAML") > -1)
                        {
                            // in text format, then we need to try library file instead
                            var newVersionPath = Path.Combine(path, "Library", "AnnotationManager");
                            if (File.Exists(newVersionPath) == true)
                            {
                                versionPath = newVersionPath;
                            }
                        }

                        // try to get version data out from binary asset
                        var binData = File.ReadAllBytes(versionPath);
                        if (binData != null && binData.Length > 0)
                        {
                            int dataLen = 7;
                            int startIndex = 20;
                            var bytes = new byte[dataLen];
                            for (int i = 0; i < dataLen; i++)
                            {
                                bytes[i] = binData[startIndex + i];
                            }
                            version = Encoding.UTF8.GetString(bytes);
                        }
                    }
                }
            }
            return version;
        }

        /// <summary>
        /// checks file version info
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileVersionData(string path)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.ProductName.Replace("(64-bit)", "").Trim();
            //return fvi.FileVersion.Replace("(64-bit)", "").Trim();
        }

        /// <summary>
        /// launch windows explorer to selected project folder
        /// </summary>
        /// <param name="folder"></param>
        public static bool LaunchExplorer(string folder)
        {
            bool result = false;
            if (Directory.Exists(folder) == true)
            {
                Process.Start(folder);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}
