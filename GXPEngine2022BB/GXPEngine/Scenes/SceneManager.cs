using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class SceneManager : GameObject
    {
        private Level1 level1 = new Level1();
        private MainMenu mainMenu = new MainMenu();
        public String currentLevel;

        GameObject levelChild; // refers to the only child this class should have and has the player in it so I can get the x and y value to do the scrolling

        public SceneManager()
        {
            
        }

        void Update()
        {
            if(levelChild != null)
            {
                this.x = -this.levelChild.x + game.width / 2;
                this.y = -this.levelChild.y + 2 * game.height / 3;
            }

        }


        public void LoadLevel(string currentLevel)
        {
           if (currentLevel == "MainMenu")
           {
                DestroyAll();
                AddChild(mainMenu);
                mainMenu.CreateLevel();
           }
           else
           {
                DestroyAll();
                AddChild(level1);
                level1.CreateLevel(currentLevel);
           }

            levelChild = this.FindObjectOfType<Player>();
        }

        private void DestroyAll()
        {
            List<GameObject> children = GetChildren();
            foreach (GameObject child in children)
            { 
                child.Destroy();
            }
        }
    }
}
