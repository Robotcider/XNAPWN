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
