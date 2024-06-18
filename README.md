# PGS (Primary Gaming Screen)
Multi-monitor application which swaps the primary display when playing games. This is to work-around games that don't let you pick which display to launch on.

![image](https://github.com/BigheadSMZ/PGS/assets/9309452/415fcd23-03e5-4e5c-b61a-33485411fe05)

# Purpose
This is a simple application written in C# .NET Framework v4.8 that swaps the primary display when launching a game and swaps it back when it closes. While some games allow you to change the screen it is displayed on using Window Key + Shift + Arrow (Left/Right), not all games will work with this method so this acts as a workaround.

# How to Use
I tried to make it as straightforward to use as possible.
- Launch the application **PGS.exe** and use the button to create a shortcut to a game executable.
- If the game requires CLI arguments, press the down arrow to reveal a textbox to enter them.
- After creating a shortcut, close it out completely. Launching it directly is just to create shortcuts.
- Open the newly created shortcut which launches PGS with the game executable as a parameter, and choose the screens you want to swap between. Primary is your main monitor, secondary is the screen to switch to.
- Press the [monitor] button to find the IDs to your monitors. They don't match up with what Windows reports.
- Games will start automatically after 5 seconds. This can be cancelled by clicking anywhere on the GUI.
- Press "OK". The program will swap the primary screen to the **Secondary Monitor ID** and show the game there.
- It will chill in the background until the game closes and restore primary display to the **Primary Monitor ID**.
- The ID values are shared across all shortcuts and are stored in the registry: *HKCU\Software\PGS\Values*.
- Timer duration before launching a game can also be configured at the registry entry above.

# Command Line
PGS is inherently a command line program. The ability to create shortcuts is just the easiest means of launching games with it. The first command sent to PGS should always be the full path to the game executable. To be safe, always surround it with quotes if you are doing things manually. If the path has spaces in it, it will divide up the path into multiple arguments and fail. Any arguments supplied after the first argument are passed through to the game executable. There are two ***Special Arguments*** that PGS recognizes if sent as the second command following the game path. When using the GUI to create shortcuts, this will be the first argument.
- **-notimer** : This completely disables the timer meaning the game will never automatically launch. Keep in mind the timer can be cancelled by clicking anywhere, and more time can be added via the registry key.
- **-nogui** : This completely disables the GUI and launches the game immediately. Even the background window is disabled, PGS is completely transparent. Keep in mind with no GUI, monitor IDs can not be configured.

To manually launch games via command line, batch scripts, custom shortcuts, game launchers, whatever, its as simple as just launching PGS.exe and entering the game executable path as an argument. The simplest example is as follows:

`PGS.exe "C:\Path\to\game\executable.exe"`

Some games may require their own command line arguments. Any arguments after the game path are sent directly to the game. For example, the game Portal uses the Half Life 2 executable:

`PGS.exe "C:\Games\Portal\hl2.exe" -game portal -steam`

Of course the exception is when using one of the above special arguments. In this case, any arguments after the special command are sent to the game. Suppose you wanted to launch Portal without the PGS GUI showing up:

`PGS.exe "C:\Games\Portal\hl2.exe" -nogui -game portal -steam`

While it should be obvious, -notimer and -nogui can't be used together nor would it make sense. There is no timer if there is no GUI. Using both will send whatever comes second to the game which could have unpredictable results.

# Caveats/Shortcomings
Because Windows is funky when it comes to primary display and IDs, there are some things to take notice of.
- This may not work on some games that use launchers. Shortcuts should always be made to a main executable.
- The "Primary" monitor ID is not the same as the one that shows in Windows or Nvidia control panel.
- Windows likes to change IDs seemingly at random. Maybe after restart, driver update, who knows what else?
- Hiding the GUI removes the ability to reconfigure the monitor IDs if they happen to change.
- If you want all your shortcuts to hide the GUI, at least keep one that always shows the GUI to change IDs later. 

# Why I Created It
I have 3x LG 1440p monitors connected through Display Port, and a 2160p LG television which I like to do some couch gaming on. I prefer to keep my center monitor as the primary display, and it's annoying to have to swap it manually to the TV when playing certain games. This program lets me work around having to perform that task manually every single time, although it is annoying that the internal IDs can seem to change at random. It doesn't seem to happen constantly, but it does happen and there's nothing we can really do about it. Heck, the ID's we get programatically don't even line up with the ones Windows reports in the display manager. 
