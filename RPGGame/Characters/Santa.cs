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

namespace RPGGame.Characters
{
    class Santa : Character
    {
        private readonly String sprite_sheet_key = "Assets/SpriteSheets/Santa"; //The string key for the content pipeline
        private readonly String portrait_key = "Assets/Portraits/Lily";         //The string key for the portrait

        private Int16 sprite_width;                                    //How wide a single sprite should be
        private Int16 sprite_height;                                   //How tall a single sprite should be
        private Int16 current_frame;                                   //The current frame of animation
        private Int16 draw_ticker;                                     //Incremental ticker for drawing
        private bool animation_pp_right;                               //Whether the animation is ping-ponging to the right 
        private Int16 run_animation_frames;                            //How many frames there are in an animation

        /// <summary>
        /// Creates a new Santa.
        /// </summary>
        public Santa() : base("Santa", null, 100, 100)
        {
            this.SpriteSheet = Managers.M_ContentManager.GetTexture(sprite_sheet_key);
            this.Portrait = Managers.M_ContentManager.GetTexture(portrait_key);
            this.current_frame = 0;
            this.sprite_width = 32;
            this.sprite_height = 46;
            this.draw_ticker = 0;
            this.animation_pp_right = true;
            this.run_animation_frames = 3;
        }

        /// <summary>
        /// Gets the centerpoint, or "origin" of the character.
        /// </summary>
        /// <returns></returns>
        public override Vector2 GetCenterpoint()
        {
            return this.Position + new Vector2(this.sprite_width / 2.0f, this.sprite_height / 2.0f) + new Vector2(0.0f, 5.0f);
        }

        /// <summary>
        /// Updates what frame of animation should currently be getting drawn.
        /// </summary>
        public void UpdateAnimationFrame()
        {
            if (this.Moving)
            {
                if (this.current_frame == 0)
                    this.current_frame = 1;

                draw_ticker++;
                if (draw_ticker % (Int16)AnimationSpeed == 0)
                {
                    if (animation_pp_right)
                    {
                        if (current_frame < run_animation_frames)
                            current_frame++;
                        else
                        {
                            animation_pp_right = false;
                            current_frame--;
                        }
                    }
                    else
                    {
                        if (current_frame > 1)
                            current_frame--;
                        else
                        {
                            animation_pp_right = true;
                            current_frame++;
                        }
                    }
                }
            }
            else
            {
                draw_ticker = 0;
                current_frame = 0;
            }
        }

        /// <summary>
        /// Draws the character to the screen.
        /// </summary>
        /// <param name="sprite_batch">The sprite batch reference.</param>
        public override void Draw(SpriteBatch sprite_batch)
        {
            UpdateAnimationFrame();

            //Old drawing, no layer inclusion
            //sprite_batch.Draw
            //(
            //    texture: SpriteSheet,
            //    sourceRectangle: new Rectangle(current_frame * sprite_width, (int)direction * sprite_height, sprite_width, sprite_height),
            //    color: Color.White,
            //    position: Helpers.H_Math.VectorLevel(Position)
            //);

            Rectangle cutout = new Rectangle(current_frame * sprite_width, (int)direction * sprite_height, sprite_width, sprite_height);
            Vector2 new_position = Helpers.H_Math.VectorLevel(Position);
            float layer = ((int)this.DrawLayer / 100.0f) + M_MapManager.GetWorldDepth(GetCenterpoint());
            sprite_batch.Draw(SpriteSheet, new_position, cutout, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, layer);
        }
    }
}
