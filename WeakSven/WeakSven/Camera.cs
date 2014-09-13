using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    instance = new Camera();

                return instance;
            }
        }

        private Camera() { }
        #endregion

        public float x;
        public float y;
        int width = Game1.SCREEN_WIDTH;
        int height = Game1.SCREEN_HEIGHT;


        public void Update(GameTime gameTime)
        {
            x = Player.Instance.Position.X - (width * 0.5f);
            y = Player.Instance.Position.Y - (height * 0.5f);
        }


    }
}
