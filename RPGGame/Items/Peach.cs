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

namespace RPGGame.Items
{
    public class Peach : Templates.T_Item
    {
        private readonly String icon_key = "Assets/Items/peach";

        /// <summary>
        /// Creates a new peach.
        /// </summary>
        public Peach(Vector2 position = default(Vector2))
        {
            this.ItemType = Inventory.I_Inventory.ItemTypes.HPHeal;
            this.Name = "Peach";
            this.Icon = M_ContentManager.GetTexture(icon_key);
            this.ItemValue = 5;
            this.ItemPower = 10;
            this.PickupDistance = 10;
            if (position == default(Vector2))
                this.Position = Vector2.Zero;
            else
                this.Position = position;
            this.Taken = false;
            GenerateKey();
        }

    }
}
