using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Button : GameObject
    {
        Sprite visualButton;
        String levelName;

        public Button(Sprite nvisualButton, TiledObject obj) : base()
        {
            this.visualButton = nvisualButton;
            levelName = obj.GetStringProperty("Load");
        }

        void Update()
        {
            if(visualButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                //visualButton.SetColor()
            }
        }
    }
}
