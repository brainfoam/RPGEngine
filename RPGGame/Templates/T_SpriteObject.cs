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
    public abstract class T_SpriteObject
    {
        private Texture2D sprite_sheet; //The object's sprite sheet
        private Vector2 position;       //The position of the object
        private float width;            //The width of the object's sprite
        private float height;           //The height of the object's sprite
        private float rotation;         //The rotation of the object's sprite
        private float anchor_x;         //The sprite's anchor point on the x axis
        private float anchor_y;         //The sprite's anchor point on the y axis

        /// <summary>
        /// Creates a new Sprite Object (for inheritance).
        /// </summary>
        /// <param name="sprite_sheet">The sprite sheet of the object.</param>
        /// <param name="x">The starting x position of the object.</param>
        /// <param name="y">The starting y position of the object.</param>
        public T_SpriteObject(Texture2D sprite_sheet, float x, float y)
        {
            this.sprite_sheet = sprite_sheet;
            this.position = new Vector2(x, y);
            this.width = 0.0f;
            this.height = 0.0f;
            this.rotation = 0.0f;
            this.anchor_x = 0.0f;
            this.anchor_y = 0.0f;
        }

        /// <summary>
        /// Gets the centerpoint, or "origin" of the object.
        /// </summary>
        /// <returns></returns>
        public virtual Vector2 GetCenterpoint()
        {
            return this.position + new Vector2(this.width / 2.0f, this.height / 2.0f);
        }

        /// <summary>
        /// Updates the sprite object.
        /// </summary>
        public virtual void Update() { } //TODO: Override in child classes

        /// <summary>
        /// Draws the sprite object to the screen.
        /// </summary>
        /// <param name="sprite_batch">Reference to the game's sprite batch.</param>
        public virtual void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw
            (
                texture: this.sprite_sheet,
                position: this.position,
                color: Color.White
            );
        }

        //Variable properties
        public Texture2D SpriteSheet { get { return sprite_sheet; } set { sprite_sheet = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public float Width { get { return width; } set { width = value; } }
        public float Height { get { return height; } set { height = value; } }
        public float Rotation { get { return rotation; } set { rotation = value; } }
        public float AnchorX { get { return anchor_x; } set { anchor_x = value; } }
        public float AnchorY { get { return anchor_y; } set { anchor_y = value; } }
    }
}
