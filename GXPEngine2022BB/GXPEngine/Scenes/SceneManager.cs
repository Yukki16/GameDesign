using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class SceneManager : GameObject
    {
        public Level1 level1 = new Level1();
        public MainMenu mainMenu = new MainMenu();


        public SceneManager(String currentLevel)
        {
            LoadLevel(currentLevel);
        }

        public void LoadLevel(string currentLevel)
        {
            if (currentLevel == "level_1")
            {
                DestroyAll();
                AddChild(level1);
                level1.CreateLevel();
            }
            else if (currentLevel == "MainMenu")
            {
                DestroyAll();
                AddChild(mainMenu);
                mainMenu.CreateLevel();
            }

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
