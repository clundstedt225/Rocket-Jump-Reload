# 🎲 Rocket Jump Reload
This project is a 3D puzzle-platformer that was created in 48 hours for the 2022 GMTK Game Jam.

The theme of this game jam was "Roll of the Dice" from which the games concept originated. The player must rocket jump to reach the end of each level, and is limited by how many rockets they recieve from their initial dice roll.

Rocket Jump Reload can be played [here in most browsers](https://conlundstedt.itch.io/rocket-jump-reload) on Itch.io since it was built using WebGL. 
(this made it easy for players to jump in try my game)

## 	:world_map: Project Navigation

All C# script files [can be found here](https://github.com/clundstedt225/Rocket-Jump-Reload/tree/main/2022GMTK/Assets/Scripts) in the scripts folder.

(Some C# scripts of note can be found below)

### _Explosion.cs_
- The [Explosion](https://github.com/clundstedt225/Rocket-Jump-Reload/blob/main/2022GMTK/Assets/Scripts/Explosion.cs) script searches for a player and applies a force in the direction of the player for the rocket jumping physics.

### _Interaction.cs_ 
- The [Interaction](https://github.com/clundstedt225/Rocket-Jump-Reload/blob/main/2022GMTK/Assets/Scripts/Interaction.cs) script both defines the "IInteractable" interface, and allows the player to constantly perform a raycast check for one of these "IInteractable" objects in the game world.


## 	:hammer_and_wrench: Tools & Languages Used
- The Unity Game Engine
- Microsoft Visual Studio IDE
- Adobe Photoshop for basic textures and graphic design
- Programmed using C#
- Hosted on the Itch.io game marketplace with WebGL

##	:stopwatch: Things I would change if I had more time
- Make longer, and more challenging levels which take better advantage of the limitation
- Add more level complications that play into the rocket jumping mechanic
- Add some sort of speed running/timed reward system for skilled players
