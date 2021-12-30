using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine.Scenes
{
    class Level1 : GameObject
    {
        Enemy enemy;
        public Player player;

        //Map level;
        TiledLoader loader;

        GameObject[,] gameObjects;


        public Level1()
        {

        }


        public void CreateLevel()
        {
            loader = new TiledLoader("Tiled/Level_1.tmx");
            loader.rootObject = this;
            loader.autoInstance = true;
            loader.addColliders = true;
            loader.LoadTileLayers(0);
            loader.addColliders = false;
            loader.LoadObjectGroups(1);
            loader.LoadObjectGroups(0);

            //loader.map.Layers[0].GetTileArray(); // gives 1 or 0

            player = FindObjectOfType<Player>();
            //enemy = FindObjectOfType<Enemy>();
            //Console.WriteLine(player);
            // Console.WriteLine(player.x + "/" +player.y);

            gameObjects = new GameObject[loader.map.Width, loader.map.Height];



            loader.OnObjectCreated += TileLoader.OnObjectCreated;

            loader.addColliders = false;

            loader.LoadTileLayers(0);

            int childCount = game.GetChildCount();

            loader.addColliders = true;

            loader.OnTileCreated += Tileloader_OnTileCreated;

            loader.LoadTileLayers(1);

            loader.OnTileCreated -= Tileloader_OnTileCreated;

            //Console.WriteLine(gameObjects);
        }
        

    }
}

