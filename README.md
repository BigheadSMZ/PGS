# PGS (Primary Gaming Screen)
Multi-monitor application which swaps the primary display when playing games. This is to work-around games that don't let you pick which display to launch on.

# Purpose
This is a simple application written in C# .NET Framework v4.8 that swaps the primary display when launching a game and swaps it back when it closes.

# How to Use
I tried to make it as straightforward to use as possible.
- Launch the application **PGS.exe** and use the button to create a shortcut to a game executable.
- After creating a shortcut to a game, close out the program. 
- Open the shortcut which launches PGS with the game executable as a parameter, and choose the two screens you want to swap between.
- Press the [?] button to find the IDs to your monitors. They do not match up with what Windows reports.
- Game will start automatically after 5 seconds. This can be cancelled by clicking anywhere on the GUI.
- Press "OK". The program will swap the primary screen to the "Secondary Monitor ID" and show the game on that screen.
- It will hang out in the background until the game closes, and restore primary display to the "Primary Monitor ID".
- The ID values are shared across all shortcuts and are stored in the registry: *HKCU\Software\Software\PGS\Values*.
- Timer duration before launching a game can also be configured at the registry entry above.

# Caveats/Shortcomings
Because Windows is funky when it comes to primary display and assigning IDs, there are some things to take notice of.
- This may not work on some games that use launchers. The shortcut should always be made to the game's main executable.
- The "Primary" monitor ID is not the same as the one that shows in Windows or Nvidia control panel.
- I implemented the ability to see the monitor IDs in v1.2.0 but I have not tested beyond my own four screens.

# Why I Created It
I have 3x LG 1440p monitors connected through Display Port, and a 2160p LG television which I like to do some couch gaming on. I prefer to keep my center monitor as the primary display, and it's annoying to have to swap it manually to the TV when playing certain games. This program lets me work around having to perform that task manually every single time, although it is annoying that the internal IDs seem to change at random.
