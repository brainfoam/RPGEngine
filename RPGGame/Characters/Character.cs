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

namespace RPGGame.Characters
{
    public class Character : Templates.T_SpriteObject
    {
        private String name;                     //The name of the character
        private Texture2D portrait;              //The texture of the character's portrait
        private float move_speed;                //How fast the character can move
        private float run_multiplier;            //Mow much the move vector should be affected when running
        private float walk_multiplier;           //Mow much the move vector should be affected when walking
        private Int16 health_max;                //The maximum health of the character
        private Int16 health_current;            //The current health of the character
        private Int16 mana_max;                  //The maximum mana of the character
        private Int16 mana_current;              //The current mana of the character
        private Int16 exp_to_next_level;         //How much EXP they need to level up
        private Int16 exp_current;               //The current EXP of the character
        private Int16 level;                     //The current level of the character
        private Int16 history_max;               //How much position history to record
        private List<Vector2> position_history;  //The last x amount of position coordinates
        private Int16 history_elements;          //How many elements have been added to the history
        private bool moving;                     //Whether the character is moving or not
        private Int16 track_distance;            //How far behind the player is from the last
        private H_Drawing.DrawLayers draw_layer; //What layer the character should be drawn on
        
        public Directions direction; //Direction enum and history variables
        private List<Directions> direction_history;
        public enum Directions
        {
            Down = 0,
            Right = 1,
            Up = 2,
            Left = 3
        }

        private AnimationSpeeds animation_speed; //How fast the character should be animated
        private List<AnimationSpeeds> animation_speed_history;
        public enum AnimationSpeeds
        {
            Walk = 10,
            Run = 5
        }

        /// <summary>
        /// Creates a new character template.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="sprite_sheet">The spritesheet for the character.</param>
        /// <param name="x">The starting X position.</param>
        /// <param name="y">The starting Y position.</param>
        public Character(String name, Texture2D sprite_sheet, float x, float y)
            : base(sprite_sheet, x, y)
        {
            this.name = name;
            this.move_speed = 1.0f;
            this.run_multiplier = 2.0f;
            this.walk_multiplier = 1.0f;
            this.health_max = this.health_current = 50;
            this.mana_max = this.mana_current = 50;
            this.exp_current = 0;
            this.exp_to_next_level = 100;
            this.level = 1;
            this.history_max = 100;
            this.position_history = new List<Vector2>();
            this.direction_history = new List<Directions>();
            this.animation_speed_history = new List<AnimationSpeeds>();
            this.moving = false;
            this.track_distance = 30;
            this.animation_speed = AnimationSpeeds.Walk;
            this.draw_layer = H_Drawing.DrawLayers.Foreground;
        }

        /// <summary>
        /// Moves the character in a vector direction.
        /// </summary>
        /// <param name="movement">The movement vector to add to the character's position.</param>
        public void Move(Vector2 movement)
        {
            this.Position += movement;
            this.moving = true;
            UpdateMovementHistory();
        }

        /// <summary>
        /// Updates the history for the character's position and direction.
        /// </summary>
        public void UpdateMovementHistory()
        {
            position_history.Insert(0, this.Position);
            direction_history.Insert(0, this.direction);
            animation_speed_history.Insert(0, this.animation_speed);
            history_elements++;
            if(position_history.Count >= history_max      || 
               direction_history.Count >= history_max     ||
               animation_speed_history.Count >= history_max)
            {
                position_history.RemoveAt(history_max - 1);
                direction_history.RemoveAt(history_max - 1);
                animation_speed_history.RemoveAt(history_max - 1);
                history_elements--;
            }
        }

        //Variable Properties
        #region Properties
        public String Name { get { return name; } set { name = value; } }
        public Texture2D Portrait { get { return portrait; } set { portrait = value; } }
        public float MoveSpeed { get { return move_speed; } set { move_speed = value; } }
        public float RunMultiplier { get { return run_multiplier; } set { run_multiplier = value; } }
        public float WalkMultiplier { get { return walk_multiplier; } set { walk_multiplier = value; } }
        public Int16 HealthMax { get { return health_max; } set { health_max = value; } }
        public Int16 Health { get { return health_current; } set { health_current = value; } }
        public Int16 ManaMax { get { return mana_max; } set { mana_max = value; } }
        public Int16 Mana { get { return mana_current; } set { mana_current = value; } }
        public Int16 EXPToNextLevel { get { return exp_to_next_level; } set { exp_to_next_level = value; } }
        public Int16 EXP { get { return exp_current; } set { exp_current = value; } }
        public Int16 Level { get { return level; } set { level = value; } }
        public bool Moving { get { return moving; } set { moving = value; } }
        public Directions Direction { get { return direction; } set { direction = value; } }
        public List<Directions> DirectionHistory { get { return direction_history; } }
        public List<Vector2> PositionHistory { get { return position_history; } }
        public List<AnimationSpeeds> AnimationSpeedHistory { get { return animation_speed_history; } }
        public Int16 HistoryElements { get { return history_elements; }}
        public Int16 TrackDistance { get { return track_distance; } set { track_distance = value; } }
        public AnimationSpeeds AnimationSpeed { get { return animation_speed; } set { animation_speed = value; } }
        public H_Drawing.DrawLayers DrawLayer { get { return draw_layer; } set { draw_layer = value; } }
        #endregion
    }
}
