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

        //static int width = 1600;
        //static int height = 1200;

        public int width { get; private set; }
        public int height { get; private set; }



        SpriteFont font;

        public List<Platform> platforms;
        //TODO: Add lists for special platforms;

        public Level(List<Platform> newPlats)
        {
            platforms = newPlats;
            width = 1600;
            height = 1200;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (Player.Instance.Rect.Intersects(platforms[i].rect))
                {
                    Player.Instance.Velocity = new Vector2(0, 0);
                    Player.Instance.Position = new Vector2(Player.Instance.Position.X, platforms[i].startPosition.Y - Player.Instance.Rect.Height );
                    break;
                }
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
