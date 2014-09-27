﻿
using System.Collections.Generic;
namespace WeakSven
{
    class LevelHandler
    {

        public Level CurrentLevel { get; private set; }

        #region Singleton Stuff
        private static LevelHandler instance = null;
        public static LevelHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelHandler();
                }

                return instance;
            }
        }

        private LevelHandler() { }
        #endregion

        public void CreateLevel1()
        {
            //Creating platforms 
            //**************************************
            List<Platform> drawPlats = new List<Platform>();
            for (int i = 0; i < 6; i++)
            {
                drawPlats.Add(new Platform((i * 50) + 100, (i * 25) + 1000, 100, 25, "portalTex"));
            }
            drawPlats.Add(new Platform(0, 1200, 1600, 25, "portalTex"));


            
            //**************************************
            CurrentLevel = new Level(drawPlats);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Platform p in drawPlats)
                p.Draw();
        }

        
    }


}
