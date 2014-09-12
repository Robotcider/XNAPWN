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
        public Vector2 origin { get; set; }

        public Camera(Viewport viewPort)
        {
           Vector2 origin = new Vector2(viewPort.Width / 2.0f, viewPort.Height / 2.0f);

        }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            return Matrix.CreateTranslation(new Vector3(origin, 0.0f));
        }
    }
}
