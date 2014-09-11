using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    class Platform
    {
        private Rectangle rect;
        private Texture2D image;
        private string imgFile;
        public int x = 0;
        public int y = 0;
        private int width;
        private int height;
        
        
        public Platform()
        {
            Init(300, 300, 100, 25);
            
        }

        public Platform(int LocX, int LocY, int newWidth, int newHeight)
        {
            Init(LocX, LocY, newWidth, newHeight);

        }

        public Platform(int LocX, int LocY, int newWidth, int newHeight, string newImage)
        {
            Init(LocX, LocY, newWidth, newHeight);
            imgFile = newImage;
        }

        private void Init(int LocX, int LocY, int newWidth, int newHeight)
        {
            x = LocX;
            y = LocY;
            width = newWidth;
            height = newHeight;
            rect = new Rectangle(x, y, width, height);
        }

        public void Load(ContentManager Content)
        {
            image = Content.Load<Texture2D>(imgFile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rect, Color.White);
        }


    }
}
