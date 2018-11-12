using System;
using System.Collections.Generic;
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
    public static class M_GlobalManager
    {
        /** IMMUTABLE VARIABLES **/
        private static readonly Int16 _SCREEN_HEIGHT = 216; //The height of the screen 
        private static readonly Int16 _SCREEN_WIDTH = 384;  //The width of the screen

        private static GameStates game_state; //The current state of the game
        public enum GameStates //Different game states
        {
            Overworld = 0,
            Battle = 1
        }

        

        /// <summary>
        /// Initalizes the global manager.
        /// </summary>
        public static void Init()
        {
            game_state = GameStates.Overworld;
        }

        public static bool CanMove()
        {
            return (game_state == GameStates.Overworld && M_MenuManager.MenuState == M_MenuManager.MenuStates.Hidden);
        }

        

        //Variable properies
        public static GameStates GameState { get { return game_state; } set { game_state = value; } }
        public static Int16 ScreenWidth { get { return _SCREEN_WIDTH; } }
        public static Int16 ScreenHeight { get { return _SCREEN_HEIGHT; } }
    }
}
