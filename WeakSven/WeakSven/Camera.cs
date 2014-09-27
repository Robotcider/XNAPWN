using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

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
                {
                    instance = new Camera();
                    instance.Speed = 15;
                    
                }

                return instance;
            }
        }

        private Camera() { }
        #endregion

		public delegate void ChangedPositionEvent(float x, float y);
		public event ChangedPositionEvent changedPosition = null;

        public float Speed { get; private set; }

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

            //Position += Velocity;
		}

        private void Move()
        {
            Position.X = Player.Instance.Position.X;
            Position.Y = Player.Instance.Position.Y - 240;  
        }
    }
}