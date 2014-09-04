using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Texture2D rect = new Texture2D();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			

        }

        protected override void Initialize()
        {
            base.Initialize();

			// Comment the following if you don't want to see the mouse
			IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
			Player.Instance.Load(Content, "Characters/PlaceHolderRob");

        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();


            if (Player.Instance.Position.X < 0)
                Player.Instance.Position.X = 0;
            if (Player.Instance.Position.Y < 0)
                Player.Instance.Position.Y = 0;

            if (Player.Instance.Position.X + Player.Instance.image.Width > Window.ClientBounds.X)
                Player.Instance.Position.X = Window.ClientBounds.X - Player.Instance.image.Width;

            if (Player.Instance.Position.Y + Player.Instance.image.Width > Window.ClientBounds.Y)
                Player.Instance.Position.Y = Window.ClientBounds.Y - Player.Instance.image.Height;
			
			Player.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			Player.Instance.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
