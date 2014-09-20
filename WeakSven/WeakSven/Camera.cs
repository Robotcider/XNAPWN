using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{

    class Camera
    {
        #region Singleton Stuff
        private static Camera instance = null;
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera();
                    instance.Speed = 15;
                }

                return instance;
            }
        }

        private Camera() { }
        #endregion

        public float Speed { get; private set; }
        public float x;
        public float y;
        int width = Game1.SCREEN_WIDTH;
        int height = Game1.SCREEN_HEIGHT;


        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                Game1.previousKeyboard.IsKeyUp(Keys.Space))
            {
                y += -Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) ||
                Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                x += -Speed;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D) ||
                Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                x += Speed;
            }
        }
    }
}
