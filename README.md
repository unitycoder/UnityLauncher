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

# Images
![unitylauncher-1](https://user-images.githubusercontent.com/5438317/29495593-0f2f1d54-85f5-11e7-929b-96fbe0147b2e.jpg)
![unitylauncher-1b](https://user-images.githubusercontent.com/5438317/29495592-0f2bdf18-85f5-11e7-9d69-a29bf1f1b4f4.jpg)
![unitylauncher-1c](https://user-images.githubusercontent.com/5438317/29495591-0ee98ef6-85f5-11e7-849f-e78977f4f473.jpg)
