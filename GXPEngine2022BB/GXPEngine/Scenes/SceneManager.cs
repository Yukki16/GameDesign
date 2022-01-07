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
                //level1 = new Level1();
                AddChild(level1);
                level1.CreateLevel(currentLevel);
           }

            player = this.FindObjectOfType<Player>();
            if (player != null)
            {
                healthUi = new HealthUI(player);
                parent.AddChild(healthUi);
                player.healthUI = this.healthUi;
            }

            
        }

        private void DestroyAll()
        {
            List<GameObject> children = GetChildren();
            foreach (GameObject child in children)
            { 
                child.Destroy();
            }

            HealthUI[] UI = parent.FindObjectsOfType<HealthUI>();
            
            foreach (HealthUI child in UI)
            { 
                child.Destroy();
            }
        }
    }
}
