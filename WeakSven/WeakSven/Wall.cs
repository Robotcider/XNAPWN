using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    public class Wall
    {
        private Texture2D img = null;
        public Rectangle rect;

        public Wall(Texture2D blockTexture, int x, int y)
        {
            img = blockTexture;
            rect = new Rectangle(x, y, Game1.SCREEN_WIDTH, Game1.SCREEN_HEIGHT);
            Camera.Instance.changedPosition += Move;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, rect, Color.White);
        }

        public void Move(float x, float y)
        {
            rect.X += (int)x;
            rect.Y += (int)y;
        }
    }
}
