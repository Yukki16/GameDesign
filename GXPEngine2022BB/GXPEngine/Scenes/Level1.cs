﻿using System;
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
            loader.LoadObjectGroups();
            
            player = FindObjectOfType<Player>();
            //enemy = FindObjectOfType<Enemy>();
            //Console.WriteLine(player);
           // Console.WriteLine(player.x + "/" +player.y);
        }
       
    }
}

