using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
	class Character : Entity
	{
        //public Texture2D image = null;
        public Animation Robanim = new Animation();

		protected Rectangle rect = new Rectangle(0, 0, 0, 0);
        
		public Vector2 Position;
		public Vector2 Velocity = Vector2.Zero;
		public float Speed { get; protected set; }

		public Character() : base() { Speed = 5.50f; }
		public Character(string name) : base(name) { Speed = 5.50f; }

		protected bool UseGravity = true;

		public virtual void Load(ContentManager Content, string imageFile)
		{
            Robanim.SpriteSheet = Content.Load<Texture2D>(imageFile);

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;

            rect.Width = Robanim.FrameWidth;
            rect.Height = Robanim.FrameHeight;
		}

		public virtual void Update(GameTime gameTime)
		{
			Position += Velocity;

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;

			if (UseGravity)
	            Velocity.Y += Physics.GRAVITY;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Robanim.Draw(spriteBatch, Position);
		}
	}
}