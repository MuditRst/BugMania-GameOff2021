# Bugmania! [GitHub GameOff 2021](https://itch.io/jam/game-off-2021)
> You play as one of **2 unique bug characters**, each with their different approach to combat, and fight in a series of hand-crafted ‘dungeons’ in a **rogue-lite fashion** and track your time completion stats and collectibles for every run!

> Latest live demo [_here_](https://mudimax.itch.io/bugmania). <!-- If you have the project hosted somewhere, include the link here. -->


## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Setup](#setup)
* [Project Status](#project-status)
* [Roadmap](#roadmap)
* [FAQ](#faq)
* [Acknowledgements](#acknowledgements)
* [License](#license)


## General Information 
- Submission for GitHub Game Off 2021. [`Check it out`](https://itch.io/jam/game-off-2021/rate/1301347)

- Read [GDD](Bugmania-GDD.pdf) for more info.

- Project made with `C#` on the `Unity` game engine, assets and visuals - `Asperite`, audio samples - `Adobe Audition`. [`Expanded on further`](#technologies-used)

<!-- You don't have to answer all the questions - just the ones relevant to your project. -->


## Technologies Used

| Technologies      | Description |
| ----------- | ----------- |
| [Unity](https://unity.com/) 2020.3.21f1     | Game engine using scripts in `C#`  to power our game      |
| Aseprite  v1.2.21| Primary tool used to make the Pixel art assets        |
| Visual Studio Code 2020     | The preferred IDE for our project       |
| Adobe Photoshop     | Finishing touches on effects and particles       |
| Adobe Audacity | Sampling the audio and sfx        |


## Features
- 12 unique levels created for fast-paced beat-up-em action.
- Implemented standardised patrol A.I for enemies, which
is based on the concept of *Dijkstra's shortest path algorithm*.
- Intuitive and seamless U.I for Menu systems and
displaying and tracking stats.

[More info on core mechanics and gameplay system features here](Bugmania-GDD.pdf).

## Setup

To work with our source code
```bash
>   clone the repository
>   verify your own Unity version ['v2020.3.21f1'] 
>   use your preferred IDE to make changes.
```

To play our Demo [Build]()
- Download the .zip folder.
- Extract it with a .rar unpacker. Consult [FAQ](#faq) for errors.
- Run the `GameOff2021.exe` executable.

## Project Status
Project is: <mark>_completed for GameJam_.</mark> 

```css
Will work on future updates.
```

## Roadmap
To do:
- [x] Add background to Main Menu.
- [x] Add a 'Win-game' condition after crossing the 12th level door.
- Complete the implementation of the 3rd playable bug [Morris the Mantis]
- Level design. Variations on the paths the player can take.

Room for improvement:
- Animations on health and collectible pickups.
- Adding variations to the bg music.
- Improving on the placeholder assets in the dungeon levels.

## FAQ

#### Files are missing after opening the .zip file with WinRar.
>Use [7zip](https://www.7-zip.org/) to open/extract the archive.
#### I cannot seem to pause the game by pressing Esc.
>The pause script is 'bugged' in some of the levels. Die to the mobs and press 'R' to restart, or Alt+F4.
#### I cannot seem to get stuck inside the hidden levels.
>The trigger collider gets messed up sometimes for moving up and down the grasshopper-specific hidden levels. Move back a few tiles, then return to that position and press the **Q** button.

## Acknowledgements
Give credit here.
- This project was inspired by Supergiant's [**Hades**](https://store.steampowered.com/app/1145360/Hades/) and Developer Digital's [**Hotline Miami**](https://store.steampowered.com/app/219150/Hotline_Miami/) and [other games]().
- Many thanks to our team

    - [Mudit Rastogi](https://github.com/MuditRst) : For countless hours of playtesting, debugging and scripting all of our little friends in the game. [**LinkedIn**](https://www.linkedin.com/in/mudit-rastogi-6aa67118b/)
    - [Shreyas Datta](https://github.com/ShreyasDatta) : For handling game design, art direction and QoL changes to the mechanics. [**LinkedIn**](https://www.linkedin.com/in/shreyas-datta-32bb041a1/) | [**Behance**](https://www.behance.net/shreyasdatta)
    - **Antariksh Mukherjee** : For helping with assets, playtesting and giving our game some personality. [**LinkedIn**](https://www.linkedin.com/in/antariksh-mukherjee-5938921b5/) | [**Behance**](https://www.behance.net/SingularityDesigns)
- Special thanks to **Ayushman Chakraborty** for the wonderful music in our game! [**Instagram**](https://www.instagram.com/a_floydian_slip/)


## License
 This project is open source and available under the [MIT License](https://github.com/ShreyasDatta/GameOff2021/blob/master/LICENSE).
