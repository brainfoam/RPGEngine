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
    public static class M_TextManager
    {
        private static readonly String main_font_key = "Assets/Fonts/Main";
        private static SpriteFont main_font;

        /// <summary>
        /// Initializes the text manager.
        /// </summary>
        public static void Init()
        {
            main_font = M_ContentManager.GetFont(main_font_key);
        }

        /// <summary>
        /// Draws a line of text to the screen (no wrapping)
        /// </summary>
        /// <param name="sprite_batch">The sprite batch reference.</param>
        /// <param name="text">The text being drawn to the screen.</param>
        /// <param name="position">The position of the text.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="font">The font the text is being rendered with.</param>
        public static void DrawText(SpriteBatch sprite_batch, String text, Vector2 position, float layer = 1.0f, Color color = default(Color), SpriteFont font = null)
        {
            if (font == null)
                font = main_font;
            if (color == default(Color))
                color = Color.White;
            sprite_batch.DrawString(font, text, position, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, layer);
        }

        //Variable properties
        public static SpriteFont MainFont { get { return main_font; } set { main_font = value; } }
    }
}
