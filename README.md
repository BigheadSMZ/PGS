# NOTICE: INFO IS OUTDATED
PGS v1.4.0 changes some things substantially. I do not have the time to update the README at the moment so read the release notes for the new version.

# PGS (Primary Gaming Screen)
Multi-monitor application which swaps the primary display when playing games. This is to work-around games that don't let you pick which display to launch on.

![image](https://github.com/BigheadSMZ/PGS/assets/9309452/80bb4019-1d5d-447e-bfea-51a8577e8102)

# Purpose
This is a simple application written in C# .NET Framework v4.8 that swaps the primary display when launching a game and swaps it back when it closes. While some games allow you to change the screen it is displayed on using Window Key + Shift + Arrow (Left/Right), not all games will work with this method so this acts as a workaround.

# How to Use
I tried to make it as straightforward to use as possible.
- Launch the application **PGS.exe** and you will be greeted with a menu to create a shortcut.
- If the game requires arguments, press the [down arrow] button to reveal a textbox to enter them.
- Create a game shortcut, close out PGS. Launching it directly is just to create shortcuts.
- Open the newly created shortcut which launches PGS with the game executable as a parameter, and choose the screens you want to swap between. Primary is your main monitor, secondary is the screen to switch to.
- Press the [monitor] button to find the IDs to your monitors. They don't match up with what Windows reports.
- Games will start automatically after 5 seconds. This can be cancelled by clicking anywhere on the GUI.
- Press "OK". The program will swap the primary screen to the **Secondary Monitor ID** and show the game there.
- It will chill in the background until the game closes and restore primary display to the **Primary Monitor ID**.

# Options Menu
Starting with PGS v1.4.0 there is now an options menu to configure certain behaviors and settings. Settings of option values are stored in an INI file named **PGS.ini**.
- To access the options menu, launch **PGS.exe** directly and not a game shortcut.
- Press the [gear] button next to the [down arrow] button to open the options menu.

There are several options that can only be configured here. They are applied globally across all shortcuts or whenever launching a game with PGS via command line. 
- **Primary/Secondary Monitor ID:** This is the same as when launching a game.
- **Timer Countdown:** The amount of time before a game will start automatically.
- **Disable Countdown Timer:** Disables the timer completely. Game will not auto-launch.
- **Immediately Launch Game:** PGS menu is hidden when launching games.
- **Save/Restore Desktop Icons:** This feature works around Desktop icons getting scattered. It saves all Desktop icon positions before switching primary display, and restores them after the primary display is swapped back.

# Command Line
PGS is inherently a command line program. The ability to create shortcuts is just the easiest means of launching games with it. The first command sent to PGS should always be the full path to the game executable. To be safe, always surround it with quotes if you are doing things manually. If the path has spaces in it, it will divide up the path into multiple arguments and fail. Any arguments supplied after the first argument are passed through and sent directly to the game executable.

# Caveats/Shortcomings
Because Windows is funky when it comes to primary display and IDs, there are some things to take notice of.
- This may not work on some games that use launchers. Shortcuts should always be made to a main executable.
- The "Primary" monitor ID is not the same as the one that shows in Windows or Nvidia control panel.
- Windows likes to change IDs seemingly at random. Maybe after restart, driver update, who knows what else?
- Hiding the GUI removes the ability to reconfigure the monitor IDs if they happen to change.
- If you want all your shortcuts to hide the GUI, at least keep one that always shows the GUI to change IDs later. 

# Why I Created It
I have 3x LG 1440p monitors connected through Display Port, and a 2160p LG television which I like to do some couch gaming on. I prefer to keep my center monitor as the primary display, and it's annoying to have to swap it manually to the TV when playing certain games. This program lets me work around having to perform that task manually every single time, although it is annoying that the internal IDs can seem to change at random. It doesn't seem to happen constantly, but it does happen and there's nothing we can really do about it. Heck, the ID's we get programatically don't even line up with the ones Windows reports in the display manager.

# Credits
If it wasn't for the site [stackoverflow](https://stackoverflow.com) and the amazing people who frequent it, this and pretty much any of my projects wouldn't be possible.
- **[Modern FolderSelectDialog](https://stackoverflow.com/questions/66823581/use-the-upgraded-folderbrowserdialog-vista-style-in-powershell):** Ben Philipp at stackoverflow
- **[Set Primary Monitor Code](https://stackoverflow.com/questions/195267/use-windows-api-from-c-sharp-to-set-primary-monitor):** ADBailey at stackoverflow
- **[Screen Friendly Name](https://stackoverflow.com/questions/4958683/how-do-i-get-the-actual-monitor-name-as-seen-in-the-resolution-dialog):** G.Y at stackoverflow
