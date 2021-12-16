using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Button : AnimationSprite
    {
        
        public Button(String buttonName) : base("Buttons/Buttons.png", 2, 4)
        {
            if (buttonName == "Play")
            {
                SetFrame(1);
            }if (buttonName == "Exit")
            {
                SetFrame(0);
            }if (buttonName == "Level_1")
            {
                SetFrame(3);
            }if (buttonName == "Settings")
            {
                SetFrame(4);
            }if (buttonName == "Level_2")
            {
                SetFrame(5);
            }if (buttonName == "Tutorial")
            {
                SetFrame(6);
            }if (buttonName == "Level_3")
            {
                SetFrame(7);
            }
            
        }
    }
}
