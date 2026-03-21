# Tower Defense Game

A 2D tower defense game built with Unity, featuring multiple enemy types, wave-based gameplay, and strategic tower placement to defend against hordes of enemies.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Setup](#setup)
- [Usage](#usage)
- [Build Instructions](#build-instructions)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Versions](#versions)

## Features

- **Wave-Based Gameplay**: Face increasingly difficult waves of enemies including Orcs, Dragons, Kaiju, Wolves, Zombies, and Franks.
- **Tower Defense Mechanics**: Place and upgrade towers to defend your base.
- **Resource Management**: Manage resources to build and upgrade towers while maintaining lives.
- **Multiple Levels**: Progress through various levels with unique challenges.
- **Object Pooling**: Efficient enemy spawning and management.
- **Audio Management**: Immersive sound effects and background music.
- **UI System**: Intuitive user interface for game controls and information display.
- **Game Speed Control**: Adjust game speed for different play styles.

## Prerequisites

- **Unity Editor**: Version 2022.3.62f3 or later
- **Operating System**: Windows, macOS, or Linux
- **Git**: For cloning the repository

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/tower-defense.git
   cd tower-defense
   ```

2. **Open in Unity**:
   - Launch Unity Hub
   - Click "Open" and select the cloned `tower-defense` folder
   - Unity will automatically detect and open the project

## Setup

1. **Package Installation**:
   - Unity will automatically install the required packages from `Packages/manifest.json`
   - Key packages include:
     - Unity 2D Feature Set
     - Universal Render Pipeline (URP)
     - Input System
     - TextMeshPro
     - Timeline
     - Visual Scripting

2. **Project Settings**:
   - Ensure the project is set to use URP (Universal Render Pipeline)
   - Check that the Input System is enabled in Project Settings > Player > Other Settings

3. **First Run**:
   - Open the main menu scene (typically `Assets/Scenes/MainMenu.unity`)
   - Press Play to start the game

## Usage

### Game Controls

- **Mouse**: Place towers, select options
- **Keyboard**: Use shortcuts for game speed (if implemented)

### Gameplay

1. **Start Game**: Select a level from the main menu
2. **Place Towers**: Use resources to build defensive towers
3. **Defend Waves**: Survive enemy waves by strategic tower placement
4. **Upgrade**: Improve towers between waves
5. **Win Condition**: Complete all waves in a level

### Development

- **Scenes**: Main scenes are located in `Assets/Scenes/`
- **Scripts**: Game logic in `Assets/Scripts/`
- **Prefabs**: Reusable objects in `Assets/Prefabs/`
- **Audio**: Sound files in `Assets/Audio/`

## Build Instructions

### For Windows

1. Go to `File > Build Settings`
2. Select `PC, Mac & Linux Standalone`
3. Choose `Windows` as Target Platform
4. Click `Build` and select output folder

### For WebGL

1. In Build Settings, select `WebGL`
2. Click `Build`

### For Mobile (Android/iOS)

1. Switch Platform to Android or iOS
2. Configure Player Settings for mobile
3. Build and deploy

**Note**: Ensure all scenes are added to the build settings in the correct order.

## Project Structure

```
Tower Defense/
├── Assets/
│   ├── Scripts/
│   │   ├── AudioManager.cs
│   │   ├── GameManager.cs
│   │   ├── LevelManager.cs
│   │   ├── Spawner.cs
│   │   ├── UIController.cs
│   │   ├── Enemy/
│   │   ├── Tower/
│   │   └── Utils/
│   ├── Scenes/
│   ├── Prefabs/
│   ├── Audio/
│   └── Materials/
├── Packages/
│   └── manifest.json
├── ProjectSettings/
└── Library/ (generated)
```

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Style

- Follow Unity's C# coding conventions
- Use meaningful variable and method names
- Add comments for complex logic
- Test changes in multiple scenes

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Versions

### Current Version: 1.0.0

#### Changelog

- **v1.0.0** - Initial release
  - Basic tower defense gameplay
  - Multiple enemy types
  - Wave system
  - Resource management
  - Level progression

#### Future Plans

- Additional tower types
- More enemy varieties
- Power-ups and special abilities
- Multiplayer support
- Mobile optimization

---

**Note**: This README assumes standard Unity project setup. Adjust paths and instructions based on your specific project configuration.