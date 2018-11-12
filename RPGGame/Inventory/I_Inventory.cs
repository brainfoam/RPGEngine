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
using System.Diagnostics;
//--------------------------------------//

namespace RPGGame.Inventory
{
    public static class I_Inventory
    {
        private static List<T_Item> inventory;  //The item array
        private static int inventory_items;     //How many items are currently in the inventory

        private static readonly int inventory_items_max = 24; //How many items are allowed in the inventory

        public enum ItemTypes
        {
            HPHeal,
            MPHeal,
            Key
        }

        /// <summary>
        /// Initializes the inventory.
        /// </summary>
        public static void Init()
        {
            inventory = new List<T_Item>();
            inventory_items = 0;
        }

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item to add to the inventory.</param>
        /// <returns></returns>
        public static bool Add(T_Item item)
        {
            Debug.WriteLine("Adding a " + item.Name + " to the inventory.");
            if (inventory_items < inventory_items_max)
            {
                inventory.Add(item);
                inventory_items++;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        /// <param name="index">The index from which to remove from the inventory.</param>
        public static void Remove(int index)
        {
            if(inventory[index] != null && index < inventory_items)
            {
                inventory.RemoveAt(index);
                inventory_items--;
            }
        }

        /// <summary>
        /// Clears the inventory.
        /// </summary>
        public static void Clear()
        {
            inventory.Clear();
            inventory_items = 0;
        }

        public static List<T_Item> Inventory { get { return inventory; } }
        public static int InventoryItems { get { return inventory_items; } }
        public static int InventoryItemsMax { get { return inventory_items_max; } }
    }
}
