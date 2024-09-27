# PGS (Primary Gaming Screen)
Multi-monitor application which swaps the primary display when playing games. This is to provide an automated way to swap the display and/or work-around games that don't let you pick or move to a different display.

![340759348-80bb4019-1d5d-447e-bfea-51a8577e8102](https://github.com/BigheadSMZ/PGS/assets/9309452/1db2b952-1287-487e-b933-79cc68a478f2)

# NOTICE
It has come to my attention that a lot of people found this application via a short by ![UFD Tech](https://www.youtube.com/ufdtech) on YouTube. While I appreciate the exposure, the video somewhat misrepresented what this application is for. It was NOT developed with the intention of solving the issue of "games launching on the wrong screen". It is to solve the issue of "launching some games on a different screen". While these two issues are similar in nature, the distinction between them is very important. The majority of games will almost always launch on the "primary display", which is exactly what this application takes advantage of. Say you want to launch some games on your main monitor, and some games on your television. This is the type of situation this application was created for, not games "launching on the wrong screen". Chances are, if the game is launching on the wrong screen, as not launching on what you have set as your "primary display", this application will most likely have no effect. If you need an example of my personal use case, scroll down to the **Why I Created It** section.

# Purpose
This is a simple application written in C# .NET Framework v4.8 that swaps the primary display when launching a game and swaps it back when it closes. While some games allow you to change the screen it is displayed on using Window Key + Shift + Arrow (Left/Right), not all games will work with this method so this acts as a work-around.

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

![image](https://github.com/BigheadSMZ/PGS/assets/9309452/56543330-d4fe-4fa6-a761-9309aa1325b5)

There are several options that can only be configured here. They are applied globally across all shortcuts or whenever launching a game with PGS via command line. 
- **Primary/Secondary Monitor ID:** This is the same as when launching a game.
- **Timer Countdown:** The amount of time before a game will start automatically.
- **Disable Countdown Timer:** Disables the timer completely. Game will not auto-launch.
- **Immediately Launch Game:** PGS menu is hidden when launching games.
- **Save/Restore Desktop Icons:** This feature works around Desktop icons getting scattered. It saves all Desktop icon positions before switching primary display, and restores them after the primary display is swapped back.

# Command Line
PGS is inherently a command line program. The ability to create shortcuts is just the easiest means of launching games with it. The first command sent to PGS should always be the full path to the game executable. To be safe, always surround it with quotes if you are doing things manually. If the path has spaces in it, it will divide up the path into multiple arguments and fail. Any arguments supplied after the first argument are passed through and sent directly to the game executable.

To manually launch games via command line, batch scripts, custom shortcuts, game launchers, whatever, its as simple as just launching PGS.exe and entering the game executable path as an argument. The simplest example is as follows:

`PGS.exe "C:\Path\to\game\executable.exe"`

Some games may require their own command line arguments. Any arguments after the game path are sent directly to the game. For example, the game Portal uses the Half Life 2 executable:

`PGS.exe "C:\Games\Portal\hl2.exe" -game portal -steam`

# Caveats/Shortcomings
Because Windows is funky when it comes to primary display and IDs, there are some things to take notice of.
- This may not work on some games that use launchers. Shortcuts should always be made to a main executable.
- The "Primary" monitor ID is not the same as the one that shows in Windows or Nvidia control panel.
- Windows likes to change IDs seemingly at random. Maybe after restart, driver update, who knows what else?
- Hiding the GUI removes the ability to reconfigure the monitor IDs from shortcuts if they happen to change.
- If you need to change monitor IDs down the road after hiding the GUI, just launch PGS.exe directly. 

# Why I Created It
I have 3x LG 1440p monitors connected through Display Port, and a LG 2160p television which I like to do some couch gaming on. I prefer to keep my center monitor as the primary display, and it's annoying to have to swap it manually to the TV when playing certain games. This program lets me work around having to perform that task manually every single time, although it is annoying that the internal IDs can seem to change at random. It doesn't seem to happen constantly, but it does happen and there's nothing we can really do about it. Heck, the ID's we get programatically don't even line up with the ones Windows reports in the display manager.

# Credits
If it wasn't for the site [stackoverflow](https://stackoverflow.com) and the amazing people who frequent it, this and pretty much any of my projects wouldn't be possible.
- **[Modern FolderSelectDialog](https://stackoverflow.com/questions/66823581/use-the-upgraded-folderbrowserdialog-vista-style-in-powershell):** Ben Philipp at stackoverflow
- **[Set Primary Monitor Code](https://stackoverflow.com/questions/195267/use-windows-api-from-c-sharp-to-set-primary-monitor):** ADBailey at stackoverflow
- **[Screen Friendly Name](https://stackoverflow.com/questions/4958683/how-do-i-get-the-actual-monitor-name-as-seen-in-the-resolution-dialog):** G.Y at stackoverflow
- **[Desktop Icon Positions](https://www.codeproject.com/Articles/639486/Save-and-Restore-Icon-Positions-on-Desktop):** Ivan Yakimov at codeproject
