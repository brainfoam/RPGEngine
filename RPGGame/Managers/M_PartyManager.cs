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
    public static class M_PartyManager
    {
        private static Characters.Character[] members; //An array for the current members in the party
        private static Int16 members_count; //The current amount of characters in the party

        /// <summary>
        /// Initializes the party manager.
        /// </summary>
        public static void Init()
        {
            members = new Characters.Character[4];
            members_count = 0;
        }

        /// <summary>
        /// Updates the characters in the party.
        /// </summary>
        public static void Update()
        {
            M_PartyMovement.Update();
            for (uint i = 0; i < members_count; i++)
            {
                members[i].Update();
            }
        }

        /// <summary>
        /// Draws the characters in the party.
        /// </summary>
        /// <param name="sprite_batch">The sprite batch reference.</param>
        public static void Draw(SpriteBatch sprite_batch)
        {
            Characters.Character[] temp_members = new Characters.Character[members.Length];
            members.CopyTo(temp_members, 0);

            //for (int i = 0; i < members_count; i++) //Sort the characters by layer/Y position
            //{
            //    for (int j = 1; j < members_count; j++)
            //    {
            //        if(temp_members[j-1].Position.Y > temp_members[j].Position.Y)
            //        {
            //            Characters.Character hold = temp_members[j];
            //            temp_members[j] = temp_members[j - 1];
            //            temp_members[j - 1] = hold;
            //        }
            //    }
            //}

            for (int i = 0; i < members_count; i++) //Draw the chrarcters
            {
                temp_members[i].Draw(sprite_batch);
            }
        }

        //Variable properties
        public static Characters.Character[] Members { get { return members; } }
        public static Int16 MembersCount { get { return members_count; } set { members_count = value; } }
    }
}
