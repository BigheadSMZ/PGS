# PGS (Primary Gaming Screen)
Multi-monitor application which swaps the primary display when playing games. This is to work-around games that don't let you pick which display to launch on.

# Purpose
This is a simple application written in C# that leverages **NirCmd.exe** to swap the primary display when launching a game.

# How to Use
I tried to make it as straightforward to use as possible.
- Launch the application **PGS.exe** and use the button to create a shortcut to a game executable.
- After creating a shortcut to a game, close out the program. 
- Open the shortcut which launches PGS with the game executable as a parameter, and choose the two screens you want to swap between.
- Press "OK". The program will run NirCMD to swap primary to the "Secondary Monitor ID" and show the game on that screen.
- It will hang out in the background until the game closes, and restore primary display to the "Primary Monitor ID".
- The ID values are shared across all shortcuts and are stored in the registry: *HKCU\Software\Software\PGS*.

# Caveats/Shortcomings
Because Windows is funky when it comes to primary display and assigning IDs, there are some things to take notice of.
- This may not work on some games that use launchers. The shortcut should always be made to the game's main executable.
- The "Primary" monitor ID that NirCMD uses is not the same as the one that shows in Windows or Nvidia control panel.
- It may take some experimenting to get the numbers right, and it seems they will change at random which is why they can be configured.

# Why I Created It
I have 3x LG 1440p monitors connected through Display Port, and a 2160p LG television which I like to do some couch gaming on. I prefer to keep my center monitor as the primary display, and it's annoying to have to swap it manually to the TV when playing certain games. This program lets me work around having to perform that task manually every single time, although it is annoying that the internal ID that NirCmd uses seems to change at random so it's far from perfect.
