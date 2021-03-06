using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine.Scenes
{
    class Level : GameObject
    {
        Enemy enemy;
        public Player player;

        //Map level;
        TiledLoader loader;
        public String levelName;

        GameObject[,] gameObjects;
        private List<GameObject> surroundingTiles = new List<GameObject>();
        private Map map;
        public List<GameObject> waypoints = new List<GameObject>();

        private SpriteBatch fillingTiles = new SpriteBatch();

        //HealthUI healthUi;
        public Level()
        {

        }


        public void CreateLevel(String levelName)
        {
            loader = new TiledLoader("Tiled/" + levelName + ".tmx");
            map = loader.map;
            loader.rootObject = this;
            

            gameObjects = new GameObject[loader.map.Width, loader.map.Height];



            loader.OnObjectCreated += Tileloader_OnObjectCreated;

            loader.autoInstance = true;
            //loader.addColliders = false;
            loader.LoadObjectGroups();
            //loader.LoadObjectGroups(0);

            //Sprite batch
            loader.rootObject = fillingTiles;
            loader.addColliders = false;
            loader.LoadTileLayers(0);

            loader.rootObject = this;

            loader.addColliders = false;

            loader.LoadTileLayers(1);

            int childCount = game.GetChildCount();

            loader.addColliders = true;

            loader.OnTileCreated += Tileloader_OnTileCreated;

            loader.LoadTileLayers(2);

            loader.OnTileCreated -= Tileloader_OnTileCreated;

            //Console.WriteLine(gameObjects);

            fillingTiles.Freeze();
            this.AddChild(fillingTiles);
        }

        private void Tileloader_OnTileCreated(Sprite sprite, int row, int column)
        {
            gameObjects[column, row] = sprite;
        }

        private void Tileloader_OnObjectCreated(Sprite sprite, TiledObject obj)
        {
            if (sprite is Player p)
            {
                //need to make sure the player is not in the object layer
                player = p;
                player.SetLevel(this);
                player.parent = this;

                
            }

            if(sprite is Enemy e)
            {
                enemy = e;
                enemy.SetLevel(this);
                enemy.parent = this;
            }

            if(sprite is Waypoint w)
            {
                waypoints.Add(w);
            }

            if(sprite is Gate gate)
            {
                gate.AddPlayer(this.player);
            }

            if(sprite is Items item)
            {
                item.AddPlayer(this.player);
                //Console.WriteLine("added player");
            }

            if(sprite is MagicTree mt)
            {
                mt.AddPlayer(this.player);
            }
        }

        public List<GameObject> GetTiles(Sprite sprite)
        {
            surroundingTiles.Clear();

            //get sprite extents and center
            Vector2[] extents = sprite.GetExtents();
            extents[0] = InverseTransformPoint(extents[0].x, extents[0].y);
            extents[2] = InverseTransformPoint(extents[2].x, extents[2].y);
            int tileSize = map.TileWidth;

            Vector2 centerPointIndex = new Vector2((int)((extents[0].x + extents[2].x) / (2 * tileSize)), (int)((extents[0].y + extents[2].y) / (2 * tileSize)));
            Vector2 topLeft = new Vector2(centerPointIndex.x - 1, centerPointIndex.y - 1);
            topLeft.x = Mathf.Clamp(topLeft.x, 0, map.Width - 1);
            topLeft.y = Mathf.Clamp(topLeft.y, 0, map.Height - 1);

            Vector2 bottomRight = new Vector2(centerPointIndex.x + 1, centerPointIndex.y + 1);
            bottomRight.x = Mathf.Clamp(bottomRight.x, 0, map.Width - 1);
            bottomRight.y = Mathf.Clamp(bottomRight.y, 0, map.Height - 1);

            for (int i = (int)topLeft.x - 1; i <= bottomRight.x + 1; i++)
            {
                for (int j = (int)topLeft.y - 1; j <= bottomRight.y + 1; j++)
                {
                    if (gameObjects[i, j] != null) surroundingTiles.Add(gameObjects[i, j]);
                }
            }

           /* Gizmos.SetColor(0, 1, 0, 1);
            Gizmos.DrawRectangle(centerPointIndex.x * tileSize + tileSize / 2, centerPointIndex.y * tileSize + tileSize / 2, tileSize, tileSize, this);

            Gizmos.SetColor(1, 0, 0, 1);
            Gizmos.DrawRectangle(centerPointIndex.x * tileSize + tileSize / 2, centerPointIndex.y * tileSize + tileSize / 2, tileSize * 3, tileSize * 3, this);
            //System.Console.WriteLine(topLeft + " / " + centerPointIndex + " / " + bottomRight + "/" + surroundingTiles.Count);*/
            return surroundingTiles;
        }
    }
}

