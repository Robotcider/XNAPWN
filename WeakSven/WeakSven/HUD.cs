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
        Vector2 playerHealthVec = new Vector2(100, 20);

        private int playerHealth;
        SpriteFont HUDFont;

		public HUD()
		{
            playerHealth = Player.Instance.Health;
		}

		public void Update(GameTime gameTime)
		{
            rect.X = Mouse.GetState().X - rect.Width / 2;
            rect.Y = Mouse.GetState().Y - rect.Height / 2;
            playerHealth = Player.Instance.Health;
        }

		public void Load(ContentManager Content)
		{
            targetRetical = Content.Load<Texture2D>("HUD/TargetRetical");
            HUDFont = Content.Load<SpriteFont>("Font");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            spriteBatch.Draw(targetRetical, rect, Color.White);

            spriteBatch.DrawString(HUDFont, "Player Health: " + playerHealth, playerHealthVec, Color.Wheat);

		}
	}
}
