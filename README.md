# Super Bario – 2D Platformer

A 2D platformer built in Unity 6 as part of My game development assignment. The project was inherited as an incomplete codebase and brought to a fully playable state through bug fixing, script completion, and new feature development.

---

## How to Play

| Action | Key |
|--------|-----|
| Move Left | Left Arrow or A |
| Move Right | Right Arrow or D |
| Jump | Spacebar |
| Shoot | J |

---

## Game Features

- **3 lives** — lose a life when hit by an enemy or falling in water
- **Respawn** — player respawns near where they fell after losing a life
- **Hit flash** — player flashes red when taking damage
- **Countdown timer** — 2 minutes to complete the level
- **Collectible coins** — collect coins scattered across the level
- **Enemies** — Snail, Beetle, Bird, Spider, Frog
- **Boss fight** — defeat the boss with 9+ hits to win
- **Game Over panel** — appears when lives run out or timer hits zero
- **Win screen** — appears after defeating the boss
- **Background music** — plays across all scenes

---

## Scenes

| Scene | Description |
|-------|-------------|
| MainMenu | Start screen with Play, Settings, and Quit |
| GameScene-ALU | Main gameplay scene |

---

## Scripts Overview

| Script | Purpose |
|--------|---------|
| `CameraFollow.cs` | Camera tracks the player with smooth follow |
| `PlayerMovement.cs` | Handles walking, jumping, and ground detection |
| `PlayerDamage.cs` | Manages lives, respawn, and hit flash effect |
| `WaterScript.cs` | Detects when player falls in water |
| `GameOverPanel.cs` | Shows game over UI and handles replay/quit |
| `WinPanel.cs` | Shows win UI after boss is defeated |
| `BossHealth.cs` | Boss requires 9 hits, triggers win on death |
| `CountdownTimer.cs` | 2-minute countdown, triggers game over at zero |
| `MainMenu.cs` | Main menu logic, settings, volume control |
| `BackgroundMusic.cs` | Persistent music across scenes |
| `MyTags.cs` | Central tag constants used across all scripts |
| `FireBullet.cs` | Bullet movement and collision logic |

---

## Setup Instructions

1. Open Unity 6 and create a new 2D Core project
2. Import the provided `.unitypackage` file
3. Open `Assets/Scenes/GameScene-ALU.unity`
4. Make sure both scenes are added to Build Settings in this order:
   - `MainMenu`
   - `GameScene-ALU`
5. Press Play from the MainMenu scene


---

## Built With

- Unity 6.4
- C#
- Unity UI (uGUI)
- TextMeshPro