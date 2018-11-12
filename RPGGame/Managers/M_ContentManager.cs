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
    public static class M_ContentManager
    {
        public static Microsoft.Xna.Framework.Content.ContentManager content_manager; //A reference to the game's content manager
        public static Dictionary<String, Texture2D> texture_library;  //A buffer for currently loaded textures
        public static Dictionary<String, SpriteFont> font_library;    //A buffer for currently loaded textures

        /// <summary>
        /// Initializes the content manager.
        /// </summary>
        /// <param name="_content_manager">The game's main content manager, for referral.</param>
        public static void Init(Microsoft.Xna.Framework.Content.ContentManager _content_manager)
        {
            texture_library = new Dictionary<String, Texture2D>();
            font_library = new Dictionary<String, SpriteFont>();
            content_manager = _content_manager;
        }

        /// <summary>
        /// Retrieves a texutre from the buffer, or loads it if it hasn't been loaded yet.
        /// </summary>
        /// <param name="key">The key for which to search for the texture in the buffer.</param>
        /// <returns></returns>
        public static Texture2D GetTexture(String key)
        {
            Texture2D buffer_retrieval = null;
            try
            {
                buffer_retrieval = texture_library[key];
            }
            catch (KeyNotFoundException)
            {
                buffer_retrieval = null;
            }
            
            if (buffer_retrieval == null) //If the texture was not in the content library, load it and add it to the dictionary
            {
                buffer_retrieval = content_manager.Load<Texture2D>(key);
                texture_library.Add(key, buffer_retrieval);
            }
            return buffer_retrieval;
        }

        /// <summary>
        /// Retrieves a font from the buffer, or loads it if it hasn't been loaded yet.
        /// </summary>
        /// <param name="key">The key for which to search for the font in the buffer.</param>
        /// <returns></returns>
        public static SpriteFont GetFont(String key)
        {
            SpriteFont buffer_retrieval = null;
            try
            {
                buffer_retrieval = font_library[key];
            }
            catch (KeyNotFoundException)
            {
                buffer_retrieval = null;
            }

            if (buffer_retrieval == null) //If the font was not in the content library, load it and add it to the dictionary
            {
                buffer_retrieval = content_manager.Load<SpriteFont>(key);
                font_library.Add(key, buffer_retrieval);
            }
            return buffer_retrieval;
        }

        //Variable properties
        public static Microsoft.Xna.Framework.Content.ContentManager ContentManager { get { return content_manager; } }
        public static Dictionary<String, Texture2D> TextureLibrary { get { return texture_library; } }
        public static Dictionary<String, SpriteFont> FontLibrary { get { return font_library; } }
    }
}
