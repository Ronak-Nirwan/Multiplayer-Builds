# Multiplayer Builds
First person multiplayer building game where players can create and join a lobby, place/ destroy blocks like Minecraft.

## Final Deliverable

- Playable multiplayer demo
- Real-time block placement sync
- Clean debug panel showing system data
- Short gameplay video
- Structured GitHub repository

## Features :-

### Phase 1 (Core Features) :-

- First Person Controller
- Placing, destroying, picking and throwing blocks (Block interaction + Building  system)
- Multiplayer - Host/ Join
- Realtime Synchronization : player movement and block placement and removal

### Phase 1.5 ( If time allows) :-

- Basic Inventory system (Different blocks)
- Simple UI for lobby

### Phase 2 (Out of Scope) :-

- Public Private lobby
- Persistent World (Save/Load multiplayer worlds)
- Visit Other Worlds

### Phase 3+ (Formatting Later on) :-

- Procedural Worlds
- Crafting system + Equipment + blocks
- physics interaction with blocks (throwing, pickup)
- Combat, other movement…….

## Systems (Execution order) :-

### Goal 1 : Core Gameplay (Single player)

- World/ Grid system
- Building system
- Interaction system

### Goal 2 : Player

- First Person Controller
- Camera + Movement
- Raycasts for interaction
- Input interfacing

### Goal 3 : Multiplayer

- Core Networking
- Host/ Client Architecture
- Network Objects Spwaning
- RPCs

### Goal 4 :  Multiplayer Sync

- Networked building system
- Basic inventory

### Goal 5 : Sessions and UX

- UI flow Host/ join
- Basic session UI

### Goal 6 : Polish & Debug

- Display : Ping/ Latency & other telemetry
- Visualize system behavior