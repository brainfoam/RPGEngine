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

namespace RPGGame.Helpers
{
    public static class H_Drawing
    {
        public enum DrawLayers
        {
            Background = 0,
            Middleground = 10,
            Foreground = 20,
            Topground = 30,
            UI = 40,
            UIOverlay = 50,
            Textbox = 60,
            TextboxText = 70,
            Alerts = 80,
            Filters = 90,
            Top = 100
        }

        /// <summary>
        /// A filler method to draw sprites to the screen.
        /// </summary>
        /// <param name="sprite_batch">The sprite batch reference.</param>
        /// <param name="texture">The texture being drawn.</param>
        /// <param name="position">The position of the sprite.</param>
        /// <param name="source_destination">The cut-out of the sprite.</param>
        public static void DrawSprite(SpriteBatch sprite_batch, Texture2D texture, Vector2 position, float layer, Rectangle source_destination = default(Rectangle), Color color = default(Color))
        {
            if (source_destination == default(Rectangle) || source_destination == null)
                source_destination = new Rectangle(0, 0, texture.Width, texture.Height);
            if (color == default(Color))
                color = Color.White;
            sprite_batch.Draw(texture, position, source_destination, color, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, layer);
        }
    }
}
