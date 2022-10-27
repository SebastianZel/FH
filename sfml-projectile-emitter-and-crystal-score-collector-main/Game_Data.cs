using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
using GameObjects;
using Game_Input;
using Game_Assets;
using Game_Score;

namespace Game_Data
{  
    public class Game
    {
        const int WIDTH = 1920;
        const int HEIGHT = 1080;
        const string TITLE = "Crystal Collector";
        public RenderWindow window;
        public View view;
        public Clock clock;
        public Music gameMusic;
        public Sound gameSound;
        public Sound collectSound;
        public Sound deathSound;
        Player player = new Player();
        Vector2f startingPosition;
        ProjectileEmitter skull1 = new ProjectileEmitter();
        ProjectileEmitter skull2 = new ProjectileEmitter();
        private List<ProjectileEmitter> projectileEmitters = new List<ProjectileEmitter>();
        CrystalSpawner crystalSpawner = new CrystalSpawner();
        Hud highScore = new Hud();
        Hud scoreTracker = new Hud();
        private List<Hud> huds = new List<Hud>();
        int score;

        public Game()
        {
            clock = new Clock();

            VideoMode mode = new VideoMode(WIDTH, HEIGHT);
            window = new RenderWindow(mode, TITLE, Styles.Close);

            window.Closed += CloseGame;
            //window.Resized += Resize;
        }

        private void CloseGame(object? sender, EventArgs e)
        {
            window?.Close();
        }

        private void Resize(object? sender, EventArgs e)
        {
            view.Size = (Vector2f)window.Size;
            //view.Center = playerSprite.Position;
        }

        private void Initialize()
        {
            //Window Settings
            window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);

            //Input
            InputManager.Instance.Init(window);

            //Assets
            AssetManager.Instance.LoadMusic("music", @".\assets\musicTrack.ogg");
            gameMusic = AssetManager.Instance.Music["music"];
            gameMusic.Volume = 30f;
            AssetManager.Instance.LoadSound("sound", @".\assets\completeSound.wav");
            gameSound = AssetManager.Instance.Sounds["sound"];
            gameSound.Volume = 20f;
            AssetManager.Instance.LoadSound("collect", @".\assets\collect.wav");
            collectSound = AssetManager.Instance.Sounds["collect"];
            AssetManager.Instance.LoadSound("death", @".\assets\GameOver.wav");
            deathSound = AssetManager.Instance.Sounds["death"];
            
            //Objects and Variables
            score = 0;
            startingPosition = new Vector2f(WIDTH/2, HEIGHT/2);
            player.Initialize();
            player.SetPosition(startingPosition);
            projectileEmitters.Add(skull1);
            projectileEmitters.Add(skull2);
            foreach (var projectileEmitter in projectileEmitters)
            {
                projectileEmitter.Initialize();
            }
            skull1.EmitterSettings(new Vector2f(750, 350), 300, false, true, true, false);
            skull2.EmitterSettings(new Vector2f(1200, 750), 200, true, true, true, true);
            crystalSpawner.Initialize();
            huds.Add(highScore);
            huds.Add(scoreTracker);
            foreach (var hud in huds)
            {
                hud.Initialize();
            }    
            highScore.SetText(new Vector2f(WIDTH/100, HEIGHT/100), HighscoreParser.Instance.GetHighScore().ToString(), 80);
            scoreTracker.SetText(new Vector2f(WIDTH/100, HEIGHT/10), score.ToString(), 80);

            view = new View((Vector2f)window.Size, (Vector2f)window.Size);
        }

        private void HandleEvents()
        {
            window.DispatchEvents();
        }

        private void PlaySounds()
        {
            if (InputManager.Instance.GetKeyDown(Keyboard.Key.Num1) && gameMusic.Status != SoundStatus.Playing)
            {
                gameMusic.Play();
            }
            if(InputManager.Instance.GetKeyDown(Keyboard.Key.Num2) && gameMusic.Status == SoundStatus.Playing)
            {
                gameMusic.Stop();
            }

            if (InputManager.Instance.GetKeyDown(Keyboard.Key.Space) && gameSound.Status != SoundStatus.Playing)
            {
                gameSound.Play();
            }
        }

        private void Update(float deltaTime)
        {
            //Updates
            foreach (ProjectileEmitter projectileEmitter in projectileEmitters)
            {
                projectileEmitter.Update(deltaTime);
            }
            crystalSpawner.Update(deltaTime);
            player.Update(deltaTime);
            foreach (var hud in huds)
            {
                hud.Update(deltaTime);
            }
            highScore.UpdateText(HighscoreParser.Instance.GetHighScore().ToString());
            scoreTracker.UpdateText(score.ToString());

            //Collisions
            foreach (ProjectileEmitter projectileEmitter in projectileEmitters)
            {
                if(player.collisionRect.Intersects(projectileEmitter.collisionRect))
                {
                    if(score > HighscoreParser.Instance.GetHighScore())
                    {
                        HighscoreParser.Instance.SetHighScore(score);
                    }
                    Restart();
                }
                foreach (Projectile projectile in projectileEmitter.projectilesAll)
                {
                    if(player.collisionRect.Intersects(projectile.collisionRect))
                    {
                        if(score > HighscoreParser.Instance.GetHighScore())
                        {
                            HighscoreParser.Instance.SetHighScore(score);
                        }
                        Restart();
                    }
                }
            }
            foreach (Crystal crystal in crystalSpawner.crystals)
            {
                if(player.collisionRect.Intersects(crystal.collisionRect))
                {
                    if(crystalSpawner.crystals.Contains(crystal))
                    {
                        crystalSpawner.PlayerCollectsCrystal(crystal);
                        AddScore();
                    }
                }
            }
            //Chessboard Borders "Collisions"
            if(player.collisionRect.Left <= 460 || player.collisionRect.Left >= 1375)
            {
                player.SetPosition(new Vector2f(WIDTH/2, HEIGHT/2));
            }
            if(player.collisionRect.Top <= 30 || player.collisionRect.Top >= 920)
            {
                player.SetPosition(new Vector2f(WIDTH/2, HEIGHT/2));
            }
            
            //view.Center = playerSprite.Position;
            PlaySounds();
        }

        private void AddScore()
        {
            collectSound.Play();
            score++;
        }

        private void Restart()
        {
            deathSound.Play();
            score = 0;
            player.SetPosition(startingPosition);
        }

        private void DrawRectangle(Vector2f position, int width, int height, Color color)
        {
            RectangleShape rectangle = new RectangleShape(new Vector2f(width, height));
            rectangle.Origin = new Vector2f(width/2, height/2);
            rectangle.Position = position;
            rectangle.FillColor = color;
            window.Draw(rectangle);
        }

        private void DrawFloor(Vector2f position, Vector2i tiles, Vector2i tileSize)
        {
            int width = tileSize.X;
            int height = tileSize.Y;
            Color white = Color.White;
            Color black = Color.Black;

            float x = position.X - (width * tiles.X/2 - tileSize.X/2);
            float y = position.Y - (height * tiles.Y/2 - tileSize.Y/2);

            for (int k = 0; k < tiles.Y; k++)
            {
                if (k % 2 == 0)
                {
                    for (int i = 0; i < tiles.X; i++)
                    {
                        if (i % 2 != 0)
                        {
                            DrawRectangle(new Vector2f(x + i * width, y + k * height), width, height, black);
                        }
                        else
                        {
                            DrawRectangle(new Vector2f(x + i * width, y + k * height), width, height, white);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < tiles.X; i++)
                    {
                        if (i % 2 == 0)
                        {
                            DrawRectangle(new Vector2f(x + i * width, y + k * height), width, height, black);
                        }
                        else
                        {
                            DrawRectangle(new Vector2f(x + i * width, y + k * height), width, height, white);
                        }
                    }
                }
            }
        }

        private void Draw()
        {
            window.Clear(Color.Blue);
            //window.SetView(view);
            DrawFloor(new Vector2f(WIDTH/2, HEIGHT/2), new Vector2i(10,10), new Vector2i(100,100));
            foreach (ProjectileEmitter projectileEmitter in projectileEmitters)
            {
                projectileEmitter.Draw(window);
            }
            crystalSpawner.Draw(window);
            player.Draw(window);
            foreach (var hud in huds)
            {
                hud.Draw(window);
            }
            window.Display();
        }

        public void Run()
        {
            Initialize();

            while(window.IsOpen)
            {
                var deltaTime = clock.Restart().AsSeconds();

                HandleEvents();

                Update(deltaTime);
                InputManager.Instance.Update();

                Draw();
            }
        }
    }
}