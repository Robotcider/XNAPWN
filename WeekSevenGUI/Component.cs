
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace WeekSevenGUI
{
    public class Component
    {
        private Texture2D square = null;
        public Rectangle rect {get; set;}

        private bool hovering = false;
        private bool released = false;
        private bool clicked = false;

        public delegate void ComponentEvent(Component sender);
        public event ComponentEvent onMouseOver = null;
        public event ComponentEvent onMouseOut = null;
        public event ComponentEvent onMouseDown = null;
        public event ComponentEvent onMouseUp = null;
        public event ComponentEvent onClick = null;

        public Component(Rectangle newRect)
        {
            rect = newRect;
            UIManager.Add(this);
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            if (rect.Contains(mouse.X, mouse.Y))
            {
                if (!hovering)
                    if (onMouseOver != null)
                        onMouseOver(this);
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (!clicked)
                        if (onMouseDown != null)
                            onMouseDown(this);
                    clicked = true;
                }
                else if(mouse.LeftButton == ButtonState.Released)
                {
                    if (!released)
                        if (onMouseUp != null)
                            onMouseUp(this);
                    if (clicked)
                        if (onClick != null)
                            onClick(this);
                    clicked = false;
                    released = true;
                    
                }
                hovering = true;
            }
            else
            {
                if (hovering)
                    if (onMouseOut != null)
                        onMouseOut(this);
                hovering = false;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
