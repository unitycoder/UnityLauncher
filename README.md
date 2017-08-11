# UnityLauncher

Tool for automatically launching specific unity versions for each project

# Features
- Automatically launch correct Unity version for your recent projects
- If correct version is not installed, UnityInstaller.exe is downloaded and started, or webpage for that version is opened
- Display Recent projects list with project version, last modified date and highlighted with green if you have this version installed
- Can be used from commandline to automatically open specific project or folder with correct version *to be updated

![UnityLauncher](https://user-images.githubusercontent.com/5438317/29217186-8b059f5c-7ee3-11e7-9cd4-0280e4b78dc4.jpg "UnityLauncher")

# Instructions
- Download, Run
- At first run you need to setup "root installations folder" (All Unity installations will be scanned under this folder)
- Recent projects list is fetched from registry (Project version and date is checked from those project folders)
- Select row from the list and click "Launch" (Launches unity with that project) or "Explore" (opens Explorer to that folder)

# Download
https://github.com/unitycoder/UnityLauncher/releases

# Sources
Project is created with VS2017 (and .net4.5)

# Reporting Bugs / Requests
https://github.com/unitycoder/UnityLauncher/issues
