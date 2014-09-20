using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeekSevenGUI;
using Microsoft.Xna.Framework.Media;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Button button = new Button(new Rectangle(300, 400, 200, 50));

		Vector2 TitleSrect = new Vector2(75, 0);

		Texture2D TitleSimage;

		public static int SCREEN_WIDTH = 0;
		public static int SCREEN_HEIGHT = 0;

		//*********************************
		protected Song TitleTheme;

		protected Song LevelSong1;

		//********************************

        public static KeyboardState previousKeyboard;

        HUD hud = new HUD();

        List<Platform> drawPlats;

        Level level1;

        //Stuff for Projectiles
        MouseState ms = new MouseState();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

			// Comment the following if you don't want to see the mouse
            //IsMouseVisible = true;
        }

        void button_onClick(Component sender)
        {
            ((Button)sender).Text = "Clicked";

            //Creating platforms 
            //**************************************
            drawPlats = new List<Platform>();
			//for (int i = 0; i < 6; i++)
			//{
			//	drawPlats.Add(new Platform((i * 100) + 100, (i * 25) + 200, 100, 25, "portalTex"));
			//}
			drawPlats.Add(new Platform(0, SCREEN_HEIGHT, 100, 25, "portalTex"));
			MediaPlayer.Stop();


			MediaPlayer.Play(LevelSong1);

            level1 = new Level(drawPlats);
            //**************************************
            level1.Load(Content);

           

			button.onClick -= button_onClick;
			button.Unload();
        }

        protected override void LoadContent()
        {
			SCREEN_WIDTH = Window.ClientBounds.Width;
			SCREEN_HEIGHT = Window.ClientBounds.Height;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            /************************************************
             * Button stuff Demo
             */
            //***********************************************
            UIManager.Init(GraphicsDevice , Content.Load<SpriteFont>("Font"));
            button.Text = "Start";

            button.onClick += button_onClick;

            //************************************************

			hud.Load(Content);

			TitleSimage = Content.Load<Texture2D>("Pictures/Robscreen");

			TitleTheme = Content.Load<Song>("Audio/Musak/ContraTitleScreen");

			LevelSong1 = Content.Load<Song>("Audio/Musak/Goldeneye");

			MediaPlayer.Play(TitleTheme);


			Player.Instance.Load(Content, "Characters/PlaceHolderRob");
            Player.Instance.Position = new Vector2(400, 300);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            UIManager.Update();

			hud.Update(gameTime);

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

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                Player.Instance.Fire(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            
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
                Player.Instance.Draw(spriteBatch);

                level1.Draw(spriteBatch);

            }
			if(level1 == null)
				spriteBatch.Draw(TitleSimage, TitleSrect, Color.White);

            UIManager.Draw(spriteBatch);

			hud.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
