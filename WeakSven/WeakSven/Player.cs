using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
	// sealed
	class Player : InteractiveCharacter
	{
		#region Singleton Stuff
		private static Player instance = null;
		public static Player Instance
		{
			get
			{
				if (instance == null)
					instance = new Player();

				return instance;
			}
		}

		private Player() : base() { }
		#endregion

        public bool jumping = false;
		public int JumpStart = 0;
		public int jumpLimit = 25;


		public void SetName(string name) { Name = name; }
		
		public override void Load(ContentManager Content, string imageFile)
		{
			base.Load(Content, imageFile);
		}

		public override void Update(GameTime gameTime)
		{
			// TODO:  Change player to my Robotic operating Buddy

            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                Game1.previousKeyboard.IsKeyUp(Keys.Space))
            {
                Velocity.Y = -25;
            }

			if (Keyboard.GetState().IsKeyDown(Keys.A) ||
				Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Velocity.X = -Speed;
			}
			
			else if (Keyboard.GetState().IsKeyDown(Keys.D) ||
				Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Velocity.X = Speed;
			}
			else
				Velocity = new Vector2(0, Velocity.Y);

            if (Position.X < 0)
            {
                Position.X = 0;
                Velocity = new Vector2(0, Velocity.Y);
            }
            else if (Position.X + rect.Width > Game1.SCREEN_WIDTH)
            {
                Position.X = Game1.SCREEN_WIDTH - rect.Width;
                Velocity = new Vector2(0, Velocity.Y);
            }

            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity = new Vector2(Velocity.X, 0);
            }

			base.Update(gameTime);
		}

        public void Landed(int floorY)
        {
            Position = new Vector2(Position.X, floorY - rect.Height);
            Velocity = new Vector2(Velocity.X, 0);
        }
	}
}