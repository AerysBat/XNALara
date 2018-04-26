using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace XNALara
{
    public class KeyboardEventHandler
    {
        private static List<Keys> keysDown = new List<Keys>();
        private static List<Keys> keysPressed = new List<Keys>();
        private static List<Keys> keysReleased = new List<Keys>();

        public static void ProcessKeyboardState(KeyboardState keyboardState) {
            keysPressed.Clear();
            Keys[] keysCurrentlyDown = keyboardState.GetPressedKeys();
            foreach (Keys keyCurrentlyDown in keysCurrentlyDown) {
                if (!keysDown.Contains(keyCurrentlyDown)) {
                    keysPressed.Add(keyCurrentlyDown);
                }
            }
            keysReleased.Clear();
            foreach (Keys keyDown in keysDown) {
                if (Array.IndexOf<Keys>(keysCurrentlyDown, keyDown) < 0) {
                    keysReleased.Add(keyDown);
                }
            }
            keysDown.Clear();
            keysDown.AddRange(keysCurrentlyDown);
        }

        public static bool HasKeyBeenPressed(Keys key) {
            return keysPressed.Contains(key);
        }

        public static bool HasKeyBeenReleased(Keys key) {
            return keysReleased.Contains(key);
        }
    }
}
