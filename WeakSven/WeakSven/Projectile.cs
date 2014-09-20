using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    class Projectile
    {
        private float speed = 0.5f;
        Vector2 position;
        Vector2 destination;

        Texture2D image;
        Rectangle rect;

        public Projectile(Vector2 origin,Vector2 newDirection, Texture2D bulletTex)
        {
            position = origin - new Vector2(Camera.Instance.x, Camera.Instance.y);

            destination = newDirection - position;
            //destination = newDirection;
            if(destination != Vector2.Zero)
                destination.Normalize();
            image = bulletTex;
            rect = new Rectangle((int)position.X, (int)position.Y, 20, 5);
        }

        public void Update(GameTime gameTime)
        {

            if (rect.Y < 2000 && rect.Y > -2000 && rect.X < 2000 && rect.X > -2000)
            {
                

                rect.X = (int)position.X - (int)Camera.Instance.x;
                rect.Y = (int)position.Y - (int)Camera.Instance.y;

                //rect.X = (int)position.X + (int)Player.Instance.Position.X;
                //rect.Y = (int)position.Y + (int)Player.Instance.Position.Y ;
                

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (rect.Y < 2000 && rect.Y > -2000 && rect.X < 2000 && rect.X > -2000)
            {
                //Rectangle drawRect = new Rectangle((int)(rect.X - Camera.Instance.x ), (int)(rect.Y - Camera.Instance.y +60), rect.Width, rect.Height);
                spriteBatch.Draw(image, rect, Color.White);
            }
        }
    }
}
