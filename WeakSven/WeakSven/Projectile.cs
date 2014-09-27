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
            
            position = origin;

            destination = newDirection;
            if(destination != Vector2.Zero)
                destination.Normalize();
            image = bulletTex;
            rect = new Rectangle((int)position.X, (int)position.Y, 20, 5);

            Camera.Instance.changedPosition += Move;

        }

        public void Update(GameTime gameTime)
        {

            if (rect.Y < 2000 && rect.Y > -2000 && rect.X < 2000 && rect.X > -2000)
            {
                position += destination * speed * gameTime.ElapsedGameTime.Milliseconds;

                rect.X = (int)position.X;
                rect.Y = (int)position.Y;         
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (rect.Y < 2000 && rect.Y > -2000 && rect.X < 2000 && rect.X > -2000)
                spriteBatch.Draw(image, rect, Color.White);
        }

        private void Move(float x, float y)
        {
            position.X += (int)x;
            position.Y += (int)y;
        }

    }
}
