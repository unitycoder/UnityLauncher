# UnityLauncher

Tool for automatically launching specific unity versions for each project (Windows only)

# Features
- Launch correct Unity version for your recent projects
- Option to download missing unity version installation or open webpage
- Display Recent projects list with project version, last modified date
- Highlight project version with green if correct unity is installed
- Open project folder in explorer
- Can be used in commandline `UnityLauncher.exe -projectPath "c:/project/path/"`
- Can ad custom Explorer context menu item to launch folder as a project: https://github.com/unitycoder/UnityLauncher/wiki/Adding-Explorer-Context-Menu

![UnityLauncher](https://user-images.githubusercontent.com/5438317/29217186-8b059f5c-7ee3-11e7-9cd4-0280e4b78dc4.jpg "UnityLauncher")

# Instructions
- Download, Run
- At first run you need to setup "root installations folder" (All Unity installations will be scanned under this folder)
- Recent projects list is fetched from registry (Project version and date is checked from those project folders)
- Select row from the list and click "Launch" (Launches unity with that project) or "Explore" (opens Explorer to that folder)

# Keyboard Shortcuts
- When recent list is selected: Enter = Launch selected, F5 = refresh recent list
- 1,2,3 to switch tabs

# Download
https://github.com/unitycoder/UnityLauncher/releases

# Sources
Project is created with VS2017 (and .net4.5)

# Reporting Bugs / Requests
https://github.com/unitycoder/UnityLauncher/issues


# Unity Forum Thread
https://forum.unity3d.com/threads/unitylauncher-launch-correct-unity-versions-for-each-project-automatically.488718/
