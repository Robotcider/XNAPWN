using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace WeakSven
{
	// sealed
	class Player : Character
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
                    //Camera.Instance.changedPosition += instance.MoveRect;
				}

				return instance;
			}
		}

		private Player() : base() { }
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
			base.Load(Content, imageFile);
            //PProjectile texture
            bulletTexture = Content.Load<Texture2D>("portalTex");

            Health = 100;
            //Position.X = 400;
            //Position.Y = 300;

            
		}

        

		public override void Update(GameTime gameTime)
		{

            Move();

            previousPosition = this.Position;
			// TODO:  Change player to my Robotic operating Buddy



            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity = new Vector2(Velocity.X, 0);
            }




            //*****************************
            //projectile shit

            if (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                 Game1.previousMouse.LeftButton == ButtonState.Released)
                Fire(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            foreach (Projectile p in bullets)
                p.Update(gameTime);
            //*****************************

			base.Update(gameTime);
		}



        public void Landed(int floorY)
        {
            Position = new Vector2(Position.X, floorY - rect.Height);
            Velocity = new Vector2(Velocity.X, 0);
        }

        public Vector2 GetPositionDifference()
        {
            return new Vector2(Position.X - previousPosition.X, Position.Y - previousPosition.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rect, Color.White);
            foreach(Projectile p in bullets)
                p.Draw(spriteBatch);
        }

        public void Fire(Vector2 mousePosition)
        {
             bullets.Add(new Projectile(new Vector2(Camera.Instance.x + 400, Camera.Instance.y + 300), mousePosition, bulletTexture));

        }

        private void MoveRect(float x, float y)
        {
            rect.X += (int)x;
            rect.Y += (int)y;
        }

        private void Move()
        {
            //if (Position.Y > Game1.SCREEN_HEIGHT) //change to level height
            //{
            //    Velocity.Y = 0;
            //    Position.Y = Game1.SCREEN_HEIGHT;
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                Game1.previousKeyboard.IsKeyUp(Keys.Space))
            {
                if (Player.Instance.Velocity != Vector2.Zero && Keyboard.GetState().IsKeyDown(Keys.Space))
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