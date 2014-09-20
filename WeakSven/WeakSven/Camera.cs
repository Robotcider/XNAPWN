using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{

	class Camera : InteractiveCharacter
    {
        #region Singleton Stuff
        private static Camera instance = null;
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                    instance = new Camera();

                return instance;
            }
        }

        private Camera() { }
        #endregion

		public delegate void ChangedPositionEvent(float x, float y);
		public event ChangedPositionEvent changedPosition = null;

        public float x;
		public float y;
        int width = Game1.SCREEN_WIDTH;
        int height = Game1.SCREEN_HEIGHT;

		private Vector2 previous = Vector2.Zero;

		public override void Update(GameTime gameTime)
		{
			Move();

			if (previous.X != Position.X || previous.Y != Position.Y)
			{
				if (changedPosition != null)
					changedPosition(previous.X - Position.X, previous.Y - Position.Y);

				previous.X = Position.X;
				previous.Y = Position.Y;
			}

			base.Update(gameTime);
		}

		private void Move()
		{
			if (Position.Y > Game1.SCREEN_HEIGHT)
			{
				Velocity.Y = 0;
				Position.Y = Game1.SCREEN_HEIGHT;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
				Game1.previousKeyboard.IsKeyUp(Keys.Space))
			{
				Velocity.Y = -15;
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

			if (Position.Y < 0)
			{
				Position.Y = 0;
				Velocity = new Vector2(Velocity.X, 0);
			}
		}
    }
}
