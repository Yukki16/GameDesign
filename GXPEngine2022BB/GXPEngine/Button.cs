using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Button : Sprite
    {
        Sprite visualButton;
        String levelName;

        public Button(TiledObject obj) : base("Buttons/" + obj.GetStringProperty("SpriteName"))
        {
            //this.visualButton = nvisualButton;
            levelName = obj.GetStringProperty("Load");
            //visualButton = new Sprite("Buttons/" + obj.GetStringProperty("SpriteName"));
        }

        void Update()
        {
            if (this != null)
            {
                if (this.HitTestPoint(Input.mouseX, Input.mouseY))
                {

                    this.SetColor(1, 1, 1);
                    if (Input.GetMouseButton(0))
                    {
                        Console.WriteLine("pressed");
                    }
                }
                else
                {
                    this.SetColor(0.8f, 0.8f, 0.8f);
                }
            }
        }
    }
}
