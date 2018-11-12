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
    public abstract class T_Item
    {
        private Inventory.I_Inventory.ItemTypes item_type; //The type of item this item is
        private String name;                               //The name of the item
        private int item_value;                            //The sell value of the item
        private int item_power;                            //How much HP/MP healing power it has
        private float pickup_dist;                         //How close you have to be to pick up the item
        private Texture2D icon;                            //The icon of the item
        private Vector2 world_position;                    //The position of the item in the world
        private bool taken;                                //Whether the item has been taken or not
        private String key;

        /// <summary>
        /// Puts itself into the player's inventory 
        /// </summary>
        public void CheckPickup()
        {
            if (M_GlobalManager.CanMove())
            {
                if (M_InputManager.KeyPressed(M_InputManager.GameKeys.Accept))
                {
                    if(Vector2.Distance(this.world_position, M_PartyManager.Members[0].GetCenterpoint()) < this.pickup_dist)
                    {
                        if(!I_Inventory.Add(this))
                        {
                            //Pull up a textbox saying "Inventory full!" or something
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates a random key for the item, to be used in inventory clearing.
        /// </summary>
        public void GenerateKey()
        {
            this.key = this.name + ":" + H_Math.RandomInt(1000, 9999);
        }

        //variable Properties
        public Inventory.I_Inventory.ItemTypes ItemType { get { return item_type; } set { item_type = value; } }
        public String Name { get { return name; } set { name = value; } }
        public int ItemValue { get { return item_value; } set { item_value = value; } }
        public int ItemPower { get { return item_power; } set { item_power = value; } }
        public float PickupDistance { get { return pickup_dist; } set { pickup_dist = value; } }
        public Texture2D Icon { get { return icon; } set { icon = value; } }
        public Vector2 Position { get { return world_position; } set { world_position = value; } }
        public bool Taken { get { return taken; } set { taken = value; } }
        public String Key { get { return key; } }
    }
}
