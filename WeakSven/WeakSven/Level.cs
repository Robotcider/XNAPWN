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

        public int x = 1600;
        public int y = 1200;

        SpriteFont font;

        public List<Platform> platforms;
        //TODO: Add lists for special platforms;

        public Level(List<Platform> newPlats)
        {
            platforms = newPlats;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Platform p in platforms)
            {
                if (Player.Instance.Rect.Intersects(p.rect))
                {
                    Player.Instance.Velocity = new Vector2(0, 0);
                    Player.Instance.Position = new Vector2(Player.Instance.Position.X, p.rect.Y - Player.Instance.Rect.Height);
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
