using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------------MAIN INCLUDE-------------//
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPGGame.Helpers;
using RPGGame.Managers;
using RPGGame.Templates;
using RPGGame.Inventory;
//--------------------------------------//

namespace RPGGame.Managers
{
    public static class M_InputManager
    {
        public enum GameKeys //The types of keys that can be used within the game
        {
            Accept = 0, //Arbitrary values, not necessary
            Back = 1,
            Up = 2,
            Right = 3,
            Down = 4,
            Left = 5,
            Start = 6,
            Esc = 7,
            Run = 8
        }

        private static KeyboardState kbs_c; //Current keyboard state
        private static KeyboardState kbs_p; //Previous keyboard state
        private static GamePadState gps_c; //Current gamepad state
        private static GamePadState gps_p; //Previous gamepad state

        public static void Init()
        {
            kbs_c = kbs_p = Keyboard.GetState();
            gps_c = gps_p = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Updates the input manager.
        /// </summary>
        public static void Update()
        {
            kbs_p = kbs_c;
            kbs_c = Keyboard.GetState();
            gps_p = gps_c;
            gps_c = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Checks whether a given key is being held down or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns></returns>
        public static bool KeyHeld(GameKeys key)
        {
            return kbs_c.IsKeyDown(FilterKeyType(key));
        }

        /// <summary>
        /// Checks whether a given key has been pressed or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns></returns>
        public static bool KeyPressed(GameKeys key)
        {
            return kbs_c.IsKeyDown(FilterKeyType(key)) && kbs_p.IsKeyUp(FilterKeyType(key));
        }

        /// <summary>
        /// Takes a game keytype and filters it into compatible XNA keytypes.
        /// </summary>
        /// <param name="key">The key being filtered.</param>
        /// <returns></returns>
        private static Microsoft.Xna.Framework.Input.Keys FilterKeyType(GameKeys key)
        {
            switch (key)
            {
                case GameKeys.Accept: return Keys.Z;
                case GameKeys.Back:   return Keys.X;
                case GameKeys.Up:     return Keys.Up;
                case GameKeys.Right:  return Keys.Right;
                case GameKeys.Down:   return Keys.Down;
                case GameKeys.Left:   return Keys.Left;
                case GameKeys.Start:  return Keys.Enter;
                case GameKeys.Esc:    return Keys.Escape;
                case GameKeys.Run:    return Keys.LeftShift;
                default:              return Keys.Z;
            }
        }

        /// <summary>
        /// The current state of the keyboard.
        /// </summary>
        public static KeyboardState KeyboardStateCurrent
        {
            get{ return kbs_c; }
            set{ /***********/ }
        }

        /// <summary>
        /// The previous state of the keyboard.
        /// </summary>
        public static KeyboardState KeyboardStatePrevious
        {
            get { return kbs_p; }
            set { /***********/ }
        }

        /// <summary>
        /// The current state of the gamepad.
        /// </summary>
        public static GamePadState GamePadStateCurrent
        {
            get { return gps_c; }
            set { /***********/ }
        }

        /// <summary>
        /// The previous state of the gamepad.
        /// </summary>
        public static GamePadState GamePadStatePrevious
        {
            get { return gps_p; }
            set { /***********/ }
        }
    }
}
