# Physics Arena Survival

A WebGL-ready, physics-based wave survival game built with Unity. Control a player using momentum-driven movement, collect powerups, and survive against waves of enemies that relentlessly chase you. Designed with simple but satisfying physics interactions and arena-style gameplay.

## 🎮 Gameplay Features

- 💥 Physics-based player movement using force
- 👾 Enemies chase the player and can be knocked back
- 🌀 Powerups provide temporary knockback abilities
- 🌊 Wave system that spawns new enemies only after clearing the current ones
- ⚠️ Game ends when the player falls off the arena
- 🌐 WebGL compatible and tested

## 🕹️ Controls

- `W` / `S` or `Up` / `Down`: Move forward or backward (relative to camera)
- `A` / `D` or `Left` / `Right`: Adjust the camera
- Powerups are collected by touching them
- Collision with enemies while powered up knocks them away

## 🧠 Tech Used

- Unity Engine
- C#
- Rigidbody physics (`AddForce`, `Impulse`)
- Coroutine-based wave and powerup management
- WebGL export optimizations


## 🏁 How to Play

Survive as long as possible by dodging and knocking back enemies using powerups. Clear all enemies in a wave to trigger the next one. Falling off the arena ends the game.

---

## ✅ Build Notes

- Optimized for WebGL (FixedUpdate used for all physics interactions)
- Physics tuned for consistent behavior across platforms
- Runs smoothly in browser and editor

---

## 📷 Screenshots

![image](https://github.com/user-attachments/assets/4d540a20-6f12-4436-96f7-f8dfb9df07a4)
![image](https://github.com/user-attachments/assets/eb1ab6b1-d441-48b5-b174-7f7079b8d8bd)
![image](https://github.com/user-attachments/assets/3ce5108d-2d9c-45e3-8cd5-3efc8f364a52)


---

## 🚧 Future Ideas (Optional)

- Add jump mechanic or dodge roll
- Score tracking or combo system
- Multiplayer support

---

## 📝 License

MIT License (or specify your preferred license here)

