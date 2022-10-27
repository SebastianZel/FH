using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using Game_Assets;

namespace GameObjects
{
    class CrystalSpawner : GameObject
    {
        Crystal crystal1 = new Crystal();
        Crystal crystal2 = new Crystal();
        Crystal crystal3 = new Crystal();
        public List<Crystal> crystals { get; private set; }
        List<Crystal> crystalSpawnList = new();
        static float timeElapsed;

        public override void Initialize()
        {

            crystals = new List<Crystal>();
            crystals.Add(crystal1);
            crystals.Add(crystal2);
            crystals.Add(crystal3);
            foreach (Crystal crystal in crystals)
            {
                crystal.Initialize();
            }
            foreach (Crystal crystal in crystals)
            {
                crystal.SetPosition(new Vector2f(0, 0));
            }
        }

        public override void Update(float deltaTime)
        {
            if(crystalSpawnList.Contains(crystal1) && crystalSpawnList.Contains(crystal2) && crystalSpawnList.Contains(crystal3))
            {
                timeElapsed = 0;
            }
            else
            {
                timeElapsed += deltaTime;
            }
            foreach (Crystal crystal in crystals)
            {
                crystal.Update(deltaTime);
            }
        }

        public override void Draw(RenderWindow window)
        {
            if(timeElapsed > 4f)
            {
                if(crystalSpawnList.Contains(crystal1) && crystalSpawnList.Contains(crystal2) && !crystalSpawnList.Contains(crystal3))
                {
                    crystalSpawnList.Add(crystal3);
                    SetCrystalPosition(crystal3);
                }
                if(crystalSpawnList.Contains(crystal1) && !crystalSpawnList.Contains(crystal2))
                {
                    crystalSpawnList.Add(crystal2);
                    SetCrystalPosition(crystal2);
                }
                if(!crystalSpawnList.Contains(crystal1))
                {
                    crystalSpawnList.Add(crystal1);
                    SetCrystalPosition(crystal1);
                }
                timeElapsed = 0f;
            }
            foreach(Crystal crystal in crystalSpawnList)
            {
                crystal.Draw(window);
            }
        }

        public override void SetPosition(Vector2f position)
        {
           
        }

        protected override void SetCollisionRect()
        {
            
        }

        private void SetCrystalPosition(Crystal crystal)
        {
            Random rnd = new Random();
            float x = rnd.Next(500, 1401); //Depends on chessboard size
            float y = rnd.Next(100, 1001); //Depends on chessboard size
            crystal.SetPosition(new Vector2f(x, y));
        }

        public void PlayerCollectsCrystal(Crystal crystal)
        {
            crystalSpawnList.Remove(crystal);
            crystal.SetPosition(new Vector2f(0,0));
        }
    }
}