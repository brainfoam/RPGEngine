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

namespace RPGGame.Templates
{
    public abstract class T_World
    {
        private List<T_Item> items = new List<T_Item>(); //The items in the world
        private int world_height;                        //The height of the world
        private int world_width;                         //The width of the world

        /// <summary>
        /// Updates the world.
        /// </summary>
        public virtual void Update() { } //To be inherited and overridden

        /// <summary>
        /// Draws the world onto the viewport.
        /// </summary>
        /// <param name="sprite_batch"></param>
        public virtual void Draw(SpriteBatch sprite_batch) { } //To be inherited and overridden

        //Variable properties
        public List<T_Item> Items { get { return items; } }
        public int WorldHeight { get { return world_height; } set { world_height = value; } }
        public int WorldWidth { get { return world_width; } set { world_width = value; } }
    }
}
