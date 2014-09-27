using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
				{
					instance = new Player();
					instance.UseGravity = true;
				}

				return instance;
			}
		}

        private Player() : base() {  }
		#endregion

        public bool jumping = false;
		public int JumpStart = 0;
		public int jumpLimit = 25;

        //Things for projectiles 
        //***********************************************
        List<Projectile> bullets = new List<Projectile>();
        Texture2D bulletTexture;
        //**********************************************

        public Vector2 previousPosition { get; private set; }
        public Rectangle Rect { get { return rect; } }

		public void SetName(string name) { Name = name; }
		
		public override void Load(ContentManager Content, string imageFile)
		{

            bulletTexture = Content.Load<Texture2D>("portalTex");
            image = Content.Load<Texture2D>(imageFile);
            Health = 100;

            rect.Width = image.Width;
            rect.Height = image.Height;


            //The numbers should be variables, I'm not sure which variables
            //See Camera.Move() for corresponding numbers
            rect.X = (int)Position.X + 400;
            rect.Y = (int)Position.Y + 240;

		}

		public override void Update(GameTime gameTime)
		{
            Move();

            previousPosition = this.Position;

            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity = new Vector2(Velocity.X, 0);
            }
            //*****************************
            //projectile shit

            if (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                 Game1.previousMouse.LeftButton == ButtonState.Released)
                Fire(new Vector2(Mouse.GetState().X - 400, Mouse.GetState().Y - 240));
            
            foreach (Projectile p in bullets)
                p.Update(gameTime);                   
            //*****************************************



            Position += Velocity;
            Velocity.Y += Physics.GRAVITY;


		}

        public void Landed(int floorY)
        {
            //Position = new Vector2(Position.X, floorY - rect.Height);
            //Velocity = new Vector2(Velocity.X, 0);
            Velocity.Y = 0;
            Position.Y = floorY - rect.Height;
            
        }

        public Vector2 GetPositionDifference()
        {
            return new Vector2(Position.X - previousPosition.X, Position.Y - previousPosition.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Rect, Color.White);
            foreach(Projectile p in bullets)
                p.Draw(spriteBatch);
        }

        public void Fire(Vector2 mousePosition)
        {
             bullets.Add(new Projectile(new Vector2(rect.X, rect.Y), mousePosition, bulletTexture));

        }


        private void Move()
        {
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