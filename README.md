# Isometric Block Catcher

A fixed-camera isometric physics game where the player controls a movable platform to catch falling blocks of varying shapes.  
If any block hits the ground, the game ends immediately.

This project is structured so **two collaborators can work in parallel from day one** without stepping on each other.

---

## Locked Design Decisions

These are agreed-on constraints. Changing them requires explicit discussion.

### Camera
- Fixed isometric camera
- Rotation: `X = 35°`, `Y = 45°`, `Z = 0°`
- Projection: **Orthographic**
- Camera does not move during gameplay

### Platform Movement Model
- Platform uses a **Kinematic Rigidbody**
- Position is controlled directly with smoothing
- Falling blocks are fully physics-driven

### Fail Condition
- **Immediate game over** if any block collider touches the ground collider
- No grace period
- No recovery state

Clarity and readability are prioritized over realism.

---

## Project Structure

Folder ownership is intentional. Avoid editing outside your area.

```
Assets/
  Game/
    Core/          // Game state, rules, events
    Managers/      // GameManager and high-level control
    Platform/      // Platform movement logic
    Blocks/        // Block behavior and spawning
    VFX/           // Particles and screen effects
    UI/            // HUD, menus, game over screen
    Audio/         // Sound effects and music
    Camera/        // Camera setup and helpers
    Lighting/      // URP lighting and volume profiles
  ThirdParty/      // Asset Store imports (do not edit)
```

---

## Team Roles

### Gameplay / Systems Owner
Responsible for making the game work.

Owns:
- Physics behavior
- Platform movement
- Block spawning
- Scoring logic
- Fail condition detection
- Game state flow

Avoids:
- Visual polish
- Particle tuning
- UI animation
- Audio mixing

Primary folders:
```
Assets/Game/Core
Assets/Game/Managers
Assets/Game/Platform
Assets/Game/Blocks
```

---

### Presentation / Feel Owner
Responsible for how the game looks and feels.

Owns:
- Camera configuration
- Lighting and URP post-processing
- Particles and feedback effects
- UI layout and animation
- Audio feedback

Avoids:
- Physics logic
- Game rules
- Direct manipulation of gameplay state

Primary folders:
```
Assets/Game/VFX
Assets/Game/UI
Assets/Game/Audio
Assets/Game/Camera
Assets/Game/Lighting
```

---

## Communication Contract

Gameplay code **fires events**.  
Presentation code **listens and reacts**.

Presentation systems must not directly modify gameplay state.

Examples of shared events:
- Block landed successfully
- Block missed
- Game over triggered
- Score changed

This separation allows parallel work without tight coupling.

---

## Scene Editing Rules

- Only **one person edits `Main.unity` at a time**
- Prefer working in prefabs and scripts
- Coordinate explicitly before touching the main scene

Scene merge conflicts are treated as stop-the-line issues.

---

## Git Workflow

- `main` branch is always playable
- Each collaborator works in a personal feature branch
- Merge early and intentionally

Example branches:
```
feature/gameplay-core
feature/presentation-polish
```

Do not commit broken scenes to `main`.

---

## Asset Policy

- Asset Store content lives in `Assets/ThirdParty`
- Vendor assets are never edited directly
- If modification is needed, duplicate assets into `Assets/Game`

Large packs may exist in the repo, but only a small curated subset should be referenced by scenes.

---

## Immediate Next Tasks

### Gameplay / Systems
- Implement platform movement
- Implement block spawning with shape variation
- Detect ground collision and trigger game over
- Track and update score

### Presentation / Feel
- Configure URP volume (bloom, vignette, color grading)
- Select and tune 2–3 particle effects
- Build score HUD and game over screen
- Add basic UI animation and audio cues

---

## Guiding Principle

Clarity beats spectacle.

Every effect, sound, or animation must communicate success, danger, or failure.  
If it does not improve readability, it does not belong.
