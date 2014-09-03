using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
	class Character : Entity
	{
		public Texture2D image = null;

		protected Rectangle rect = new Rectangle(0, 0, 0, 0);

		public Vector2 Position;
		public Vector2 Velocity = Vector2.Zero;
		public float Speed { get; protected set; }

		public Character() : base() { Speed = 1.75f; }
		public Character(string name) : base(name) { Speed = 1.75f; }

		public virtual void Load(ContentManager Content, string imageFile)
		{
			image = Content.Load<Texture2D>(imageFile);

			rect.Width = image.Width;
			rect.Height = image.Height;

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;
		}

		public virtual void Update(GameTime gameTime)
		{
			Position += Velocity;

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(image, rect, Color.White);
		}
	}
}