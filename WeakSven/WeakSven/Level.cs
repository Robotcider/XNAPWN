using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    class Level
    {

        static int x = 1600;
        static int y = 1200;

        SpriteFont font;

        public List<Platform> platforms;
        //TODO: Add lists for special platforms;

        public Level(List<Platform> newPlats)
        {
            platforms = newPlats;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < platforms.Count(); i++)
            {
                platforms[i].Update(gameTime);
                //platforms[i].rect.X = (int)(platforms[i].startPosition.X - Camera.Instance.x);
                //platforms[i].rect.Y = (int)(platforms[i].startPosition.Y - Camera.Instance.y);
            }
        }

        public void Load(ContentManager Content)
        {
            foreach (Platform p in platforms)
            {
                p.Load(Content);
            }

            font = Content.Load<SpriteFont>("Font");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Platform p in platforms)
            {
                p.Draw(spriteBatch);
            }

        }
    }
}
