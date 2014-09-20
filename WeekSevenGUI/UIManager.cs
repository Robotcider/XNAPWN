using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeekSevenGUI
{
    public class UIManager
    {

        public static Texture2D square { get; private set; }
        public static SpriteFont font { get; private set; }
        private static List<Component> components = new List<Component>();
		private static List<Component> removing = new List<Component>();

        private UIManager(){}

        public static void Add(Component uiElement)
        {
            components.Add(uiElement);
        }

        public static void Init(GraphicsDevice graphics, SpriteFont font)
        {
            UIManager.font = font;

            UIManager.square = new Texture2D( graphics, 1, 1);
            UIManager.square.SetData(new Color[] { Color.White });
        }

		public static void Remove(Component UIelement)
		{
			removing.Add(UIelement);
		}

        public static void Update()
        {
            foreach (Component c in components)
                c.Update();

			if (removing.Count > 0)
			{
				for (int i = 0; i < removing.Count; i++)
					components.Remove(removing[i]);

				removing.Clear();
			}
        }

		public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component c in components)
                c.Draw(spriteBatch);
        }
    }
}
