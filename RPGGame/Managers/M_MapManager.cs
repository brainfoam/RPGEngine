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
    public static class M_MapManager
    {
        private static Worlds.W_TestWorld world;

        /// <summary>
        /// Initializes the world manager.
        /// </summary>
        public static void Init()
        {
            world = new Worlds.W_TestWorld();
        }

        /// <summary>
        /// Gets a drawing depth based on the position of the object in the world.
        /// </summary>
        /// <param name="position">The position to find the depth of.</param>
        /// <returns></returns>
        public static float GetWorldDepth(Vector2 position)
        {
            if (position.Y >= world.WorldHeight)
                return 1.0f;
            return MathHelper.Lerp(0.0f, .1f, position.Y / world.WorldHeight);
        }

        /// <summary>
        /// Updates the world manager.
        /// </summary>
        public static void Update()
        {

        }

        /// <summary>
        /// Draws the world to the viewport.
        /// </summary>
        /// <param name="sprite_batch"></param>
        public static void Draw(SpriteBatch sprite_batch)
        {
            world.Draw(sprite_batch);
        }
    }
}
