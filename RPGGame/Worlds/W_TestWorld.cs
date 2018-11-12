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

namespace RPGGame.Worlds
{
    class W_TestWorld : Templates.T_World
    {
        public W_TestWorld()
        {
            this.WorldHeight = 2000;
            this.WorldWidth = 2000;

            Managers.M_PartyManager.Members[0] = new Characters.Santa();
            Managers.M_PartyManager.Members[1] = new Characters.Santa();
            Managers.M_PartyManager.Members[2] = new Characters.Santa();
            Managers.M_PartyManager.Members[3] = new Characters.Santa();
            Managers.M_PartyManager.MembersCount = 4;

            this.Items.Add(new Items.Peach(new Vector2(100,100)));
        }

        public override void Update()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].CheckPickup();
            }
        }

        public override void Draw(SpriteBatch sprite_batch)
        {
            for(int i = 0; i < this.Items.Count; i++)
            {
                float layer = (int)H_Drawing.DrawLayers.Foreground / 100.0f + M_MapManager.GetWorldDepth(this.Items[i].Position);
                H_Drawing.DrawSprite(sprite_batch, this.Items[i].Icon, this.Items[i].Position, layer);
            }
        }
        
    }
}
