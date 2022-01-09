using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class PushableObject : AnimationSprite
    {
        public PushableObject(String name, int rows, int cols, TiledObject obj) : base(name, rows, cols, -1, true)
        { 
        
        }
    }
}
