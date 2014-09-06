﻿using Microsoft.Xna.Framework;
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

            Health = 100;
		}

		public override void Update(GameTime gameTime)
		{
			// TODO:  Change player to my Robotic operating Buddy

			if (jumping == true)
				Player.instance.Position.Y -= 10.0f;

			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				jumping = true;

			}

			if (Keyboard.GetState().IsKeyUp(Keys.Space))
				jumping = false;

			if (Keyboard.GetState().IsKeyDown(Keys.A) ||
				Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Velocity.X = -Speed;
				Velocity.Y -= 3.5f;
			}
			
			else if (Keyboard.GetState().IsKeyDown(Keys.D) ||
				Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Velocity.X = Speed;
				Velocity.Y -= 3.5f;
			}
			else
				Velocity = Vector2.Zero;


			Velocity.Y += Physics.GRAVITY;

			base.Update(gameTime);
		}

        public Rectangle getRect()
        {
            return base.rect;
        }
	}
}