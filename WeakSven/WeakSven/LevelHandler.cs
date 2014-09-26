
using System.Collections.Generic;
namespace WeakSven
{
    class LevelHandler
    {

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

        public Level CreateLevel1()
        {
            Level newLevel = null;

            //Creating platforms 
            //**************************************
            List<Platform> drawPlats = new List<Platform>();
            for (int i = 0; i < 6; i++)
            {
                drawPlats.Add(new Platform((i * 50) + 100, (i * 25) + 200, 100, 25, "portalTex"));
            }
            drawPlats.Add(new Platform(0, 1200, 1600, 25, "portalTex"));


            newLevel = new Level(drawPlats);
            //**************************************

            return newLevel;
        }
    }


}
