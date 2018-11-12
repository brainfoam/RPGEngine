using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//-------------MAIN INCLUDE-------------//
using RPGGame.Helpers;
using RPGGame.Managers;
using RPGGame.Templates;
using RPGGame.Inventory;
//--------------------------------------//

namespace RPGGame
{
    public class RPGGame : Game
    {
        GraphicsDeviceManager graphics; //The call to the graphics card
        SpriteBatch sprite_batch; //The sprite batch reference

        /// <summary>
        /// Creates the game class.
        /// </summary>
        public RPGGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = M_GlobalManager.ScreenHeight;
            graphics.PreferredBackBufferWidth = M_GlobalManager.ScreenWidth;
            Content.RootDirectory = "Content";
            Window.Position = new Point
            (
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2), 
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2)
            );
        }

        /// <summary>
        /// Initalizes the objects and managers in the game.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            M_ContentManager.Init(Content);
            M_GlobalManager.Init();
            M_TextManager.Init();
            M_InputManager.Init();
            M_PartyManager.Init();
            M_MenuManager.Init();
            I_Inventory.Init();
            M_MapManager.Init();
        }

        /// <summary>
        /// For loading content (unnecessary - content loaded ASYNC)
        /// </summary>
        protected override void LoadContent()
        {
            sprite_batch = new SpriteBatch(GraphicsDevice);
            //-------------------------------------------//
        }

        /// <summary>
        /// For unloading content (again, unnecessary)
        /// </summary>
        protected override void UnloadContent()
        {
            //-------------------------------------------//
        }

        /// <summary>
        /// Updates the game variables and managers.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            M_InputManager.Update();
            M_MapManager.Update();
            M_PartyManager.Update();
            M_MenuManager.Update();
            M_MapManager.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// Main draw call for the GPU.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            sprite_batch.Begin(SpriteSortMode.FrontToBack);
            M_MapManager.Draw(sprite_batch);
            M_PartyManager.Draw(sprite_batch);
            M_MenuManager.Draw(sprite_batch);
            M_MapManager.Draw(sprite_batch);
            sprite_batch.End();

            base.Draw(gameTime);
        }
    }
}
