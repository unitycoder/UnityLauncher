# UnityLauncher

Tool for automatically launching specific unity versions for each project (Windows only)

# Features
- Automatically launch correct Unity version for your recent projects
- If correct version is not installed, UnityInstaller.exe is downloaded and started, or webpage for that version is opened
- Display Recent projects list with project version, last modified date and highlighted with green if you have this version installed
- Quicly open project folder in Explorer
- Can be used from commandline to automatically open specific project or folder with correct version: 
`UnityLauncher.exe -projectPath "c:/project/path/"`
- Can setup custom Explorer context menu item to launch current folder as project: https://github.com/unitycoder/UnityLauncher/wiki/Adding-Explorer-Context-Menu

![UnityLauncher](https://user-images.githubusercontent.com/5438317/29217186-8b059f5c-7ee3-11e7-9cd4-0280e4b78dc4.jpg "UnityLauncher")

# Instructions
- Download, Run
- At first run you need to setup "root installations folder" (All Unity installations will be scanned under this folder)
- Recent projects list is fetched from registry (Project version and date is checked from those project folders)
- Select row from the list and click "Launch" (Launches unity with that project) or "Explore" (opens Explorer to that folder)

# Keyboard Shortcuts
- When recent list is selected: Enter = Launch selected, F5 = refresh recent list

# Download
https://github.com/unitycoder/UnityLauncher/releases

# Sources
Project is created with VS2017 (and .net4.5)

# Reporting Bugs / Requests
https://github.com/unitycoder/UnityLauncher/issues


# Unity Forum Thread
https://forum.unity3d.com/threads/unitylauncher-launch-correct-unity-versions-for-each-project-automatically.488718/
