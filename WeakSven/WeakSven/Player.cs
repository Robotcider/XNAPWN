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
					instance.UseGravity = false;
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

		public void SetName(string name) { Name = name; }
		
		public override void Load(ContentManager Content, string imageFile)
		{
			base.Load(Content, imageFile);
            //PProjectile texture
            bulletTexture = Content.Load<Texture2D>("portalTex");

            Health = 100;
			Position.X = (Game1.SCREEN_WIDTH - rect.Width) * 0.5f;
			Position.Y = (Game1.SCREEN_HEIGHT - rect.Height) * 0.5f;
		}

		public override void Update(GameTime gameTime)
		{

            previousPosition = this.Position;
			// TODO:  Change player to my Robotic operating Buddy

<<<<<<< HEAD
=======
            

            //if (Position.X < 0)
            //{
            //    Position.X = 0;
            //    Velocity = new Vector2(0, Velocity.Y);
            //}
            //else if (Position.X + rect.Width > Game1.SCREEN_WIDTH)
            //{
            //    Position.X = Game1.SCREEN_WIDTH - rect.Width;
            //    Velocity = new Vector2(0, Velocity.Y);
            //}

            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity = new Vector2(Velocity.X, 0);
            }


>>>>>>> origin/master
            foreach (Projectile p in bullets)
                p.Update(gameTime);



			base.Update(gameTime);

		}

        public Rectangle Rect { get { return rect; } }

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
	}
}