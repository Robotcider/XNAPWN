using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
	class HUD
	{
		Texture2D targetRetical = null;
        Rectangle rect = new Rectangle(0, 0, 25, 25);

		public HUD()
		{

		}

		public void Update(GameTime gameTime)
		{
            rect.X = Mouse.GetState().X - rect.Width / 2;
            rect.Y = Mouse.GetState().Y - rect.Height / 2;
        }

		public void Load(ContentManager Content)
		{
            targetRetical = Content.Load<Texture2D>("HUD/TargetRetical");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            spriteBatch.Draw(targetRetical, rect, Color.White);
		}
	}
}
