using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class SceneManager : GameObject
    {
        private Scenes.Level level1 = new Level();
        private MainMenu mainMenu = new MainMenu();
        //public String SceneName;

        enum PossibleScenes
        {
            Menu,
            Level
        }

        PossibleScenes currentPossibleScene;

        public SFX sfx = new SFX();

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
                this.LoadLevel("SelectingMenu");
            }

        }


        public void LoadLevel(string currentSceneName)
        {
            if (!currentSceneName.Contains("Level"))
            {
                currentPossibleScene = PossibleScenes.Menu;
            }
            else
            {
                currentPossibleScene = PossibleScenes.Level;
            }

            //this.SceneName = currentSceneName;

            if (currentPossibleScene == PossibleScenes.Menu)
            {
                RemoveAllChildren();
                mainMenu = new MainMenu();
                mainMenu.CreateLevel(currentSceneName);
                AddChild(mainMenu);
                sfx.PlayMusic(false);
                //Console.WriteLine(mainMenu == null);

            }
            else
            {
                RemoveAllChildren();
                level1 = new Level();
                level1.CreateLevel(currentSceneName);
                AddChild(level1);
                level1.levelName = currentSceneName;

                sfx.PlayMusic(true);
            }

            player = this.FindObjectOfType<Player>();
            if (player != null)
            {
                healthUi = new HealthUI(player);
                parent.AddChild(healthUi);
                player.healthUI = this.healthUi;
                player.sceneManager = this;
                player.sfx = this.sfx;
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
                if(child != sfx)
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
