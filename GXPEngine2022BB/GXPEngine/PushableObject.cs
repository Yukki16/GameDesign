using GXPEngine.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class PushableObject : AnimationSprite
    {
        private float fallingSpeed = 0;

        private Level1 currentLevel;
        private Player player;
        public PushableObject(String name, int rows, int cols, TiledObject obj) : base(name, rows, cols, -1, true)
        {
            this.collider.isTrigger = true;
        }

        void Update()
        {
            VerticalMovement();
            //HorizontalMovement();
            //x += 1;
            
        }
        void VerticalMovement()
        {

            if (MoveUntilCollision(0, fallingSpeed, currentLevel.GetTiles(this)) != null)
            {
                fallingSpeed = 0;
            }
            else
            {
                fallingSpeed += 1;
            }
        }

        public void SetVars(Level1 level, Player p)
        {
            currentLevel = level;
            player = p;
        }

        public void HorizontalMovement()
        {
            MoveUntilCollision(player.xSpeed, 0, currentLevel.GetTiles(this));
            //Console.WriteLine(player.xSpeed);
        }
    }
}
