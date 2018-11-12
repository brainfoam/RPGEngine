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
    public static class M_MenuManager
    {
        private static Vector2 menu_position;                                    //The current position of the menu
        private static String stats_menu_key = "Assets/Menus/StatsMenu";         //The string key for the stats menu
        private static String inventory_menu_key = "Assets/Menus/InventoryMenu"; //The string key for the inventory menu
        private static String options_menu_key = "Assets/Menus/OptionsMenu";     //The string key for the options menu
        private static String menu_fade_key = "Assets/Menus/MenuFade";        //The string key for the menu fade
        private static Texture2D stats_menu;                                     //The stats menu texture
        private static Texture2D inventory_menu;                                 //Thhe inventory menu texture
        private static Texture2D options_menu;                                   //The options menu texture
        private static Texture2D menu_fade;                                      //The menu's background fade texture
        private static Vector2[] member_positions;                               //The positions of members on the stats screen

        private static readonly int inventory_columns = (int)Math.Floor(Inventory.I_Inventory.InventoryItemsMax / 8.0);
        private static readonly int inventory_rows = (int)Math.Floor(Inventory.I_Inventory.InventoryItemsMax / 3.0);
        private static readonly int inventory_column_spacing = 90;
        private static readonly int inventory_row_spacing = 14;
        private static readonly Vector2 inventory_position = new Vector2(80, 40);

        private static MenuStates menu_state; //The state of the base menu
        public enum MenuStates
        {
            Hidden = 0,
            Open = 1
        }

        private static MenuTabStates menu_tab_state; //The state of the menu's current tab
        public enum MenuTabStates
        {
            Stats = 0,
            Inventory = 1,
            Options = 2
        }

        /// <summary>
        /// Initializes the menu Manager.
        /// </summary>
        public static void Init()
        {
            menu_position = Vector2.Zero;
            stats_menu = M_ContentManager.GetTexture(stats_menu_key);
            inventory_menu = M_ContentManager.GetTexture(inventory_menu_key);
            options_menu = M_ContentManager.GetTexture(options_menu_key);
            menu_fade = M_ContentManager.GetTexture(menu_fade_key);
            menu_state = MenuStates.Hidden;
            menu_tab_state = MenuTabStates.Stats;
            member_positions = new Vector2[4];
            member_positions[0] = new Vector2(70, 40);
            member_positions[1] = new Vector2(190, 40);
            member_positions[2] = new Vector2(70, 100);
            member_positions[3] = new Vector2(190, 100);
        }

        /// <summary>
        /// Updates the menu manager.
        /// </summary>
        public static void Update()
        {
            switch(menu_state)
            {
                case (MenuStates.Hidden):
                    if(M_InputManager.KeyPressed(M_InputManager.GameKeys.Start))
                    {
                        menu_state = MenuStates.Open;
                        menu_position += new Vector2(0.0f, 10.0f);
                    }
                    break;

                case (MenuStates.Open):

                    menu_position = Helpers.H_Math.LerpThreshold(menu_position, Vector2.Zero, 0.3f);

                    if (M_InputManager.KeyPressed(M_InputManager.GameKeys.Start))
                    {
                        menu_state = MenuStates.Hidden;
                        menu_tab_state = MenuTabStates.Stats;
                    }

                    if (M_InputManager.KeyPressed(M_InputManager.GameKeys.Right))
                    {
                        menu_tab_state = (MenuTabStates)MathHelper.Clamp((int)++menu_tab_state, 0, 2);
                        menu_position += new Vector2(0.0f, 1.0f);
                    }
                    else if (M_InputManager.KeyPressed(M_InputManager.GameKeys.Left))
                    {
                        menu_tab_state = (MenuTabStates)MathHelper.Clamp((int)--menu_tab_state, 0, 2);
                        menu_position += new Vector2(0.0f, 1.0f);
                    }
                    break;
            }
        }

        /// <summary>
        /// Draws the menu to the screen.
        /// </summary>
        /// <param name="sprite_batch"></param>
        public static void Draw(SpriteBatch sprite_batch)
        {
            Texture2D menu_texture = null;
            if(menu_state == MenuStates.Open)
            {
                float backdrop_layer = (((int)H_Drawing.DrawLayers.UI) / 100.0f ) - 0.0001f;
                H_Drawing.DrawSprite(sprite_batch, menu_fade, Vector2.Zero, backdrop_layer, default(Rectangle), new Color(255,255,255,100));

                switch (menu_tab_state)
                {
                    case MenuTabStates.Stats:     menu_texture = stats_menu;     break;
                    case MenuTabStates.Inventory: menu_texture = inventory_menu; break;
                    case MenuTabStates.Options:   menu_texture = options_menu;   break;
                }

                Vector2 new_menu_position = H_Math.VectorLevel(menu_position);
                float ui_layer = ((int)H_Drawing.DrawLayers.UI) / 100.0f;
                H_Drawing.DrawSprite(sprite_batch, menu_texture, new_menu_position, ui_layer);
                float overlay_layer = ((int)H_Drawing.DrawLayers.UIOverlay) / 100.0f;

                switch (menu_tab_state)
                {
                    case MenuTabStates.Stats:

                        for (uint i = 0; i < M_PartyManager.MembersCount; i++)
                        {
                            Vector2 position = menu_position + member_positions[i];
                            H_Drawing.DrawSprite(sprite_batch, M_PartyManager.Members[i].Portrait,position, overlay_layer);
                            M_TextManager.DrawText(sprite_batch, M_PartyManager.Members[i].Name, position + new Vector2(36, -2), overlay_layer);
                            M_TextManager.DrawText(sprite_batch, "HP: " + M_PartyManager.Members[i].Health + "/" + M_PartyManager.Members[i].HealthMax, position + new Vector2(36, 10), overlay_layer);
                            M_TextManager.DrawText(sprite_batch, "MP: " + M_PartyManager.Members[i].Mana + "/" + M_PartyManager.Members[i].ManaMax, position + new Vector2(36, 22), overlay_layer);
                        }

                        break;

                    case MenuTabStates.Inventory:

                        int slot = 0;
                        for(int i = 0; i < inventory_rows; i++)
                        {
                            for(int j = 0; j < inventory_columns; j++)
                            {
                                Vector2 slot_position = menu_position + inventory_position + new Vector2(j * inventory_column_spacing, i * inventory_row_spacing);
                                if (slot < I_Inventory.InventoryItems)
                                    M_TextManager.DrawText(sprite_batch, I_Inventory.Inventory[slot].Name, slot_position, overlay_layer, Color.White);
                                else
                                    M_TextManager.DrawText(sprite_batch, "-----", slot_position, overlay_layer, Color.Gray);
                                slot++;
                            }
                        }

                        break;

                    case MenuTabStates.Options:

                        break;
                }
            }
        }

        public static MenuStates MenuState { get { return menu_state; } set { menu_state = value; } }
        public static MenuTabStates MenuTabState { get { return menu_tab_state; } set { menu_tab_state = value; } }
    }
}
