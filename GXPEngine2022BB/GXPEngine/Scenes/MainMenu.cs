using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine.Scenes
{
    class MainMenu : GameObject
    {
        TiledLoader loader;
        public MainMenu() : base()
        {
            
        }

        public void CreateLevel()
        {
            loader = new TiledLoader("Tiled/MainMenu.tmx");
            loader.rootObject = this;
            loader.autoInstance = true;
            loader.LoadImageLayers(0);
            loader.addColliders = true;
            loader.LoadTileLayers(0);
            loader.LoadObjectGroups();

            //player = FindObjectOfType<Player>();
            //Console.WriteLine(player);
            // Console.WriteLine(player.x + "/" +player.y);
        }
    }
}
