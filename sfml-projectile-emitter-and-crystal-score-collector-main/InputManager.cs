using System;
using System.Collections;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;
using Game_Data;

namespace Game_Input
{
    public class InputManager
    {
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }
        
        private InputManager()
        {
            
        }

        private Dictionary<Keyboard.Key, bool> isKeyPressed = new Dictionary<Keyboard.Key, bool>();
        private Dictionary<Keyboard.Key, bool> isKeyDown = new Dictionary<Keyboard.Key, bool>();
        private Dictionary<Keyboard.Key, bool> isKeyUp = new Dictionary<Keyboard.Key, bool>();

        public void Init(Window window)
        {
            window.SetKeyRepeatEnabled(false);
            
            isKeyPressed.Add(Keyboard.Key.W, false);
            isKeyPressed.Add(Keyboard.Key.A, false);
            isKeyPressed.Add(Keyboard.Key.S, false);
            isKeyPressed.Add(Keyboard.Key.D, false);
            isKeyPressed.Add(Keyboard.Key.Space, false);
            isKeyPressed.Add(Keyboard.Key.Num1, false);
            isKeyPressed.Add(Keyboard.Key.Num2, false);

            isKeyDown.Add(Keyboard.Key.W, false);
            isKeyDown.Add(Keyboard.Key.A, false);
            isKeyDown.Add(Keyboard.Key.S, false);
            isKeyDown.Add(Keyboard.Key.D, false);
            isKeyDown.Add(Keyboard.Key.Space, false);
            isKeyDown.Add(Keyboard.Key.Num1, false);
            isKeyDown.Add(Keyboard.Key.Num2, false);
            
            isKeyUp.Add(Keyboard.Key.W, false);
            isKeyUp.Add(Keyboard.Key.A, false);
            isKeyUp.Add(Keyboard.Key.S, false);
            isKeyUp.Add(Keyboard.Key.D, false);
            isKeyUp.Add(Keyboard.Key.Space, false);
            isKeyUp.Add(Keyboard.Key.Num1, false);
            isKeyUp.Add(Keyboard.Key.Num2, false);
            
            window.KeyPressed += CloseGameEscape;

            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;
        }

        public void Update()
        {
            foreach(KeyValuePair<Keyboard.Key, bool> Kvp in isKeyDown)
            {
                isKeyDown[Kvp.Key] = false;
            }
            foreach(KeyValuePair<Keyboard.Key, bool> Kvp in isKeyUp)
            {
                isKeyUp[Kvp.Key] = false;
            }
        }

        private void CloseGameEscape(object? sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private void OnKeyPressed(object? sender, KeyEventArgs e)
        {
            isKeyDown[e.Code] = true;

            isKeyPressed[e.Code] = true;
        }

        private void OnKeyReleased(object? sender, KeyEventArgs e)
        {
            isKeyPressed[e.Code] = false;
            
            isKeyUp[e.Code] = true;
        }

        public bool GetKeyPressed(Keyboard.Key key)
        {
            if(isKeyPressed.ContainsKey(key) && isKeyPressed[key] == true)
            {
                return true;
            }
            return false;
        }

        public bool GetKeyDown(Keyboard.Key key)
        {
            if(isKeyDown.ContainsKey(key) && isKeyDown[key] == true)
            {
                return true;
            }
            return false;
        }

        public bool GetKeyUp(Keyboard.Key key)
        {
            if(isKeyUp.ContainsKey(key) && isKeyUp[key] == true)
            {
                return true;
            }
            return false;
        }

        public void ClearAll()
        {
            isKeyPressed.Clear();
            isKeyDown.Clear();
            isKeyUp.Clear();
        }
    }
}