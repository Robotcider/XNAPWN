using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		public static int SCREEN_WIDTH = 0;
		public static int SCREEN_HEIGHT = 0;


        public static KeyboardState previousKeyboard;


        HUD hud = new HUD();
        //Texture2D rect = new Texture2D();

        Platform testPlat = new Platform(400, 100, 100, 25, "portalTex");

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			

        }

        protected override void Initialize()
        {
            base.Initialize();

			SCREEN_WIDTH = Window.ClientBounds.Width;
			SCREEN_HEIGHT = Window.ClientBounds.Height;
			// Comment the following if you don't want to see the mouse
            //IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
			Player.Instance.Load(Content, "Characters/PlaceHolderRob");

            hud.Load(Content);

            testPlat.Load(Content);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            if (Player.Instance.Position.Y + Player.Instance.image.Height > Window.ClientBounds.Height)
                Player.Instance.Landed(Window.ClientBounds.Height);
			
			Player.Instance.Update(gameTime);

            hud.Update(gameTime);


            base.Update(gameTime);
            previousKeyboard = Keyboard.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();

            hud.Draw(spriteBatch);
			Player.Instance.Draw(spriteBatch);
            testPlat.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
