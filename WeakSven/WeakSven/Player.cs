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


		public Vector2 Position = new Vector2(0, 0);


		public void SetName(string name) { Name = name; }
		
		public override void Load(ContentManager Content, string imageFile)
		{
			base.Load(Content, imageFile);
		}

		public override void Update(GameTime gameTime)
		{
			// TODO:  Change player to my Robotic operating Buddy

			if (Keyboard.GetState().IsKeyDown(Keys.A) ||
				Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Velocity.X = -Speed;
				Velocity.Y += 1;
			}

			else if (Keyboard.GetState().IsKeyDown(Keys.D) ||
				Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Velocity.X = Speed;
				Velocity.Y += 1;
			}
			else
				Velocity = Vector2.Zero;


			Velocity.Y += Physics.GRAVITY;

			base.Update(gameTime);
		}
	}
}