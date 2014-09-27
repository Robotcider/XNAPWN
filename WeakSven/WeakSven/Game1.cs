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
        public static MouseState previousMouse;

        HUD hud = new HUD();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();           
        }

        void button_onClick(Component sender)
        {
            ((Button)sender).Text = "Clicked";
		
			MediaPlayer.Stop();

			MediaPlayer.Play(LevelSong1);
          
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

            //currentLevel = LevelHandler.Instance.CreateLevel1();
            LevelHandler.Instance.CreateLevel1();
            if(LevelHandler.Instance.CurrentLevel != null)
                LevelHandler.Instance.CurrentLevel.Load(Content);

            
			TitleSimage = Content.Load<Texture2D>("Pictures/Robscreen");

			TitleTheme = Content.Load<Song>("Audio/Musak/ContraTitleScreen");

			LevelSong1 = Content.Load<Song>("Audio/Musak/Goldeneye");

			MediaPlayer.Play(TitleTheme);


			Player.Instance.Load(Content, "Characters/PlaceHolderRob");
            //TODO: Create spawnpoint vector in each level, spawn player at point
            Player.Instance.Position = new Vector2(400, 600);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            UIManager.Update();

			hud.Update(gameTime);

            if (LevelHandler.Instance.CurrentLevel == null)
                return;


            
			Player.Instance.Update(gameTime);
            Camera.Instance.Update(gameTime);


            LevelHandler.Instance.Update(gameTime);


            previousKeyboard = Keyboard.GetState();
            previousMouse = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (LevelHandler.Instance.CurrentLevel != null)
            {
                Player.Instance.Draw(spriteBatch);
                LevelHandler.Instance.Draw(spriteBatch);
            }
			if(LevelHandler.Instance.CurrentLevel == null)
				spriteBatch.Draw(TitleSimage, TitleSrect, Color.White);

            UIManager.Draw(spriteBatch);

			hud.Draw(spriteBatch);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
