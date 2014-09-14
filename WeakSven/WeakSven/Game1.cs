using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeekSevenGUI;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Button button = new Button(new Rectangle(0, 0, 200, 50));

		public static int SCREEN_WIDTH = 0;
		public static int SCREEN_HEIGHT = 0;

        public static KeyboardState previousKeyboard;

        HUD hud = new HUD();

        //Testing Camera;

        List<Platform> drawPlats;

        Level level1;

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

        void button_onClick(Component sender)
        {
            ((Button)sender).Text = "Clicked";

            //Creating platforms 
            //**************************************
            drawPlats = new List<Platform>();
            for (int i = 5; i < 6; i++)
            {
                drawPlats.Add(new Platform((i * 100) + 100, (i * 25) + 200, 100, 25, "portalTex"));
            }

            level1 = new Level(drawPlats);
            //**************************************
            level1.Load(Content);

            hud.Load(Content);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /************************************************
             * Button stuff Demo
             */
            //***********************************************
            UIManager.Init(GraphicsDevice , Content.Load<SpriteFont>("Font"));
            button.Text = "Game";

            button.onClick += button_onClick;

            
            //************************************************

			Player.Instance.Load(Content, "Characters/PlaceHolderRob");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            UIManager.Update();

            if (level1 == null)
                return;

            if (Player.Instance.Position.Y + Player.Instance.image.Height > Window.ClientBounds.Height)
                Player.Instance.Landed(Window.ClientBounds.Height);

            for (int i = 0; i < level1.platforms.Count; i++)
            {
                if (Player.Instance.Rect.Intersects(level1.platforms[i].rect))
                {
                     Player.Instance.Velocity = new Vector2(0, 0);
                    Player.Instance.Position = new Vector2(Player.Instance.Position.X, level1.platforms[i].rect.Y + level1.platforms[i].rect.Height);
                    break;
                }
            }
            
			Player.Instance.Update(gameTime);
            Camera.Instance.Update(gameTime);
            level1.Update(gameTime);

            hud.Update(gameTime);

            base.Update(gameTime);
            previousKeyboard = Keyboard.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (level1 != null)
            {
                hud.Draw(spriteBatch);
                Player.Instance.Draw(spriteBatch);

                level1.Draw(spriteBatch);
            }

            UIManager.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
