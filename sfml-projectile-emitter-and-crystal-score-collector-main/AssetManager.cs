using System;
using System.Collections;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;

namespace Game_Assets
{
    public class AssetManager
    {
        private static AssetManager instance;

        public static AssetManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssetManager();
                }
                return instance;
            }
        }

        private AssetManager(){}

        public readonly Dictionary<string, Texture> Textures = new Dictionary<string, Texture>();
        public readonly Dictionary<string, Music> Music = new Dictionary<string, Music>();
        public readonly Dictionary<string, Sound> Sounds = new Dictionary<string, Sound>();
        public readonly Dictionary<string, Font> Fonts = new Dictionary<string, Font>();

        public void LoadTexture(string name, string fileName)
        {
            Texture texture = new Texture(fileName);
            Textures.Add(name, texture);
        }

        public void LoadMusic(string name, string fileName)
        {
            Music music = new Music(fileName);
            Music.Add(name, music);
        }

        public void LoadSound(string name, string fileName)
        {
            SoundBuffer soundbuffer = new SoundBuffer(fileName);
            Sound sound = new Sound(soundbuffer);
            Sounds.Add(name, sound);
        }

        public void LoadFont(string name, string fileName)
        {
            Font font = new Font(fileName);
            Fonts.Add(name, font);
        }
    }
}