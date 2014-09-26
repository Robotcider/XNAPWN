using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    class InteractiveCharacter : Character
    {
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int Money { get; protected set; }
        
        public virtual void  Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
