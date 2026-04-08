# 🥔 DataCenter-Potato

> A MelonLoader mod for **Data Center** that disables particle effects to squeeze out extra performance on lower-end machines.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![MelonLoader](https://img.shields.io/badge/MelonLoader-0.7.2-green)](https://github.com/LavaGang/MelonLoader)
[![Language: C#](https://img.shields.io/badge/Language-C%23-purple)](https://docs.microsoft.com/en-us/dotnet/csharp/)

---

## 📖 About

**DataCenter-Potato** strips out in-game particle effects (dust, sparks, ambient FX, etc.) that aren't essential to gameplay. The result is a leaner experience with improved frame rates — ideal for potato PCs, laptops, or anyone who'd rather have smooth gameplay over visual flair.

Press **M** at any time in-game to toggle particle effects on or off.

---

## ✨ What It Does

- Toggle all `ParticleSystem` components on/off at runtime with the **M key**
- No visual corruption — gameplay and UI are unaffected
- Zero impact on save files or game progression

---

## 🛠 Requirements

| Requirement | Version |
|---|---|
| [MelonLoader](https://github.com/LavaGang/MelonLoader/releases) | 0.6.x |
| .NET Framework / Unity Mono | Bundled with game |
| Data Center (the game) | Latest |

---

## 📦 Installation

### Step 1 — Install MelonLoader

1. Download the **MelonLoader installer** from the [MelonLoader releases page](https://github.com/LavaGang/MelonLoader/releases).
2. Run the installer, click the game tab, and point it at your **Data Center** `.exe`.
3. Click **Install** and let it finish.
4. Launch the game once to let MelonLoader generate its folder structure, then close it.

Your game folder should now look something like this:

```
DataCenter/
├── Mods/          ← mod .dll files go here
├── UserLibs/
├── MelonLoader/
├── DataCenter.exe
└── ...
```

### Step 2 — Install This Mod

**Option A — Download a release**

Download the latest `.dll` from the [Releases](https://github.com/ASavageSwan/-DataCenter-Potato/releases) page and drop it into the `Mods/` folder.

**Option B — Build from source**

```bash
git clone https://github.com/ASavageSwan/-DataCenter-Potato.git
cd DataCenter-Potato
dotnet build --configuration Release
```

Copy the compiled `DataCenter-Potato.dll` from `DataCenter-Potato/bin/Release/` into your game's `Mods/` folder:

```
<GameFolder>/Mods/DataCenter-Potato.dll
```

### Step 3 — Launch the Game

Start Data Center normally. MelonLoader will load the mod automatically — you'll see it listed in the MelonLoader console on startup. Particle effects should be gone immediately.

---

## 🔧 Building from Source

**Prerequisites:** .NET SDK (6.0+ recommended), Visual Studio or `dotnet` CLI

```bash
# Clone the repo
git clone https://github.com/ASavageSwan/-DataCenter-Potato.git
cd DataCenter-Potato

# Restore dependencies and build
dotnet restore
dotnet build --configuration Release
```

The output `.dll` will be at:
```
DataCenter-Potato/bin/Release/netstandard2.1/DataCenter-Potato.dll
```

> **Note:** You may need to update the reference paths to `MelonLoader.dll` and `UnityEngine.dll` in the `.csproj` to point at your local game/MelonLoader installation.

---

## 🗑 Uninstalling

Delete `DataCenter-Potato.dll` from the `Mods/` folder. All particle effects will return to normal on the next game launch.

---

## 🤝 Contributing

Pull requests and issues are welcome! If you find a particle system that slips through, or want to add config options (e.g. selectively disable only certain effects), feel free to open a PR.

1. Fork the repo
2. Create a feature branch (`git checkout -b feature/my-change`)
3. Commit your changes
4. Open a pull request

---

## 📄 License

© 2026 [ASavageSwan](https://github.com/ASavageSwan)

This project is licensed under the **MIT License** — see [LICENSE](LICENSE) for details.
