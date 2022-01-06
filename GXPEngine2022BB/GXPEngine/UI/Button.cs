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
        //GameObject myGame;
        String levelName;
        Scenes.SceneManager sceneManager;//= new Scenes.SceneManager();

        public Button(TiledObject obj) : base("Buttons/" + obj.GetStringProperty("SpriteName"))
        {
            levelName = obj.GetStringProperty("Load");

            sceneManager = parent.parent.parent.FindObjectOfType<Scenes.SceneManager>();
            //Console.WriteLine(myGame);
        }

        void Update()
        {
            if (this != null)
            {
                if (this.HitTestPoint(Input.mouseX, Input.mouseY))
                {

                    this.SetColor(1, 1, 1);
                    if (Input.GetMouseButtonUp(0))
                    {
                        
                        //Console.WriteLine("pressed");
                        //parent.parent.parent.RemoveChild(parent.parent); //removes the scene manager from MyGame, I can't believe it actually works
                                                                        //Button > MainMenu > SceneManager > MyGame   //why the fuck do I need this?!
                        sceneManager.LoadLevel(levelName);
                        //myGame.AddChild(sceneManager);
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
