# 🎮 TheTown

**TheTown** est un jeu vidéo développé par notre équipe, mêlant point & click, réflexion, jeu d'horreur, exploration, ... dans un univers captivant et original. Ce repo contient tout le code source, les assets et la documentation nécessaires au bon fonctionnement du projet.

---

## 🛠️ Technologies utilisées

- Unity 6000.0.30f1, FMOD 2.0.3, Blender
- C#
  
---

## 📂 Structure du dépôt

TheTown/
├── FMOD/ # Projet FMOD contenant le son du jeu 
├── TheTown/ # Projet Unity
    └── Assets/ # Dossier source contenant les textures, assets, scripts
        ├── Scripts/
            ├── Player/
            ├── AI/
            ├── Managers/
            ├── Dialogs/
            └── Quests/
        ├── Shaders/
        ├── Animations/
            ├── Player/
            ├── Villagers/
            ├── Monster/
            └── Environment/
        ├── Scenes/
        ├── Prefabs/
        ├── Audios/
            ├── SFX/
            └── Musics/
        └── Imports/
            ├── Models3D/
            ├── Sprites/
            └── Textures/
└── Docs/ # Documentation du jeu 

---

## 🧭 Conventions internes

Pour faciliter la contribution et la maintenance :

- **Nom des fichiers :** `CamelCase` pour les scripts, `snake_case` pour les assets.
- **Branches Git :** 
  - `main` → version stable
  - `dev` → développement actif sur laquelle se basent nos branches
- **Commit messages :** Suivre le format `:gitmoji: [type] message`, par exemple :
  - `✨ [feat] Ajout du menu principal`
  - `🐛 [fix] Correction de bug collision`
- **Commit sur une issue :** Suivre le format `:gitmoji: #<ISSUE_ID> CA-<X> message`, par exemple:
  > CA pour Critère d'Acceptation, pour clore l'issue quand tous les critères sont remplis
  - `🎨 #11 CA-2 Import Bar Model3D`
- **Langue principale du code :** Anglais

---

## 🚀 Lancement du projet

1. Cloner le dépôt :  
   `git clone https://github.com/P10-Studio/TheTown.git`

2. Ouvrir le projet TheTown avec Unity 6000.0.30f1

3. Ouvrir le projet FMOD avec FMOD 2.0.3

4. Build ou lancer depuis l’éditeur pour tester.
