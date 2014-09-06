using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    class PortalTwoWay
    {
        private int portalHeight = 100;
        private int portalWidth = 25;
        private Rectangle RectPortal1;
        private Rectangle RectPortal2;

        private Texture2D portalTex =null;

        Vector2 VecPortal1, VecPortal2;
        Vector2 VecPortalDest1, VecPortalDest2;

        public PortalTwoWay(Vector2 newportal1, Vector2 newportal2)
        {
            VecPortal1 = newportal1;
            VecPortal2 = newportal2;

            VecPortalDest1 = new Vector2(VecPortal1.X + 30, VecPortal1.Y);
            VecPortalDest2 = new Vector2(VecPortal2.X + 30, VecPortal2.Y);

            RectPortal1 = new Rectangle((int)VecPortal1.X, (int)VecPortal1.Y, portalWidth, portalHeight);
            RectPortal2 = new Rectangle((int)VecPortal2.X, (int)VecPortal2.Y, portalWidth, portalHeight);


        }

        public void Load(ContentManager Content)
        {
            portalTex = Content.Load<Texture2D>("portalTex");
        }


        public void Update()
        {
            //TODO: Detect player collision



            if (RectPortal1.Intersects(Player.Instance.getRect()))
                Player.Instance.Position = VecPortalDest2;

            if (RectPortal2.Intersects(Player.Instance.getRect()))
                Player.Instance.Position = VecPortalDest1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(portalTex, RectPortal1, Color.White);
            spriteBatch.Draw(portalTex, RectPortal2, Color.White);

            
        }
    }
}
