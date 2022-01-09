using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class SceneManager : GameObject
    {
        private Scenes.Level1 level1 = new Level1();
        private MainMenu mainMenu = new MainMenu();
        public String currentLevel;


        HealthUI healthUi;

        Player player;

        public SceneManager()
        {
            
        }

        void Update()
        {
            if(player != null)
            {
                this.x = -this.player.x + game.width / 2;
                this.y = -this.player.y + 2 * game.height / 3;
            }

            if (Input.GetKeyDown(Key.Q))
            {
                this.LoadLevel("LevelSelecter");
            }

        }


        public void LoadLevel(string currentLevel)
        {
           if (currentLevel == "MainMenu" || currentLevel == "LevelSelecter")
           {
                RemoveAllChildren();
                mainMenu = new MainMenu();
                mainMenu.CreateLevel(currentLevel);
                AddChild(mainMenu);
                //Console.WriteLine(mainMenu == null);
                
           }
           else
           {
                RemoveAllChildren();
                level1 = new Level1();
                level1.CreateLevel(currentLevel);
                AddChild(level1);
                level1.levelName = this.currentLevel;
           }

            player = this.FindObjectOfType<Player>();
            if (player != null)
            {
                healthUi = new HealthUI(player);
                parent.AddChild(healthUi);
                player.healthUI = this.healthUi;
                player.sceneManager = this;
            }

            this.x = 0;
            this.y = 0;
            
        }

        private void RemoveAllChildren()
        {
            List<GameObject> children = this.GetChildren();
            //Console.WriteLine(children.Count);
            foreach (GameObject child in children)
            {
                //Console.WriteLine("destroied");
                //Console.WriteLine(mainMenu == null);
                //Console.WriteLine(level1 == null);
                child.Remove();
            }
            
            HealthUI[] UI = game.FindObjectsOfType<HealthUI>();
            
            if(UI != null)
            foreach (HealthUI child in UI)
            { 
                child.Remove();
            }
        }
    }
}
