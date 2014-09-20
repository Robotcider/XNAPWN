using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WeekSevenGUI
{
    public class Button : Component
    {
        private Vector2 textPosition = Vector2.Zero;

        public string text = string.Empty;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;

                Vector2 widthHeight = UIManager.font.MeasureString(text);
                textPosition = new Vector2(
                    rect.X + ((rect.Width / 2) - (widthHeight.X / 2)),
                    rect.Y + ((rect.Height / 2) - (widthHeight.Y / 2))
                    );
            }
        }

        public Button(Rectangle rect)
            : base(rect) 
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(UIManager.square, rect, Color.White);
            spriteBatch.DrawString(UIManager.font, text, textPosition, Color.Black);
        }
    }
}
