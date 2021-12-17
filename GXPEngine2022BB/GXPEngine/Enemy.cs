using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Enemy : Sprite
    {
        String enemyFileName;
        float fallingSpeed = 0;

        AnimationSprite enemyAnimation;
        public Enemy(TiledObject obj) : base("Enemies/Debug.png")
        {
            SetOrigin(width / 2, height / 2);

            this.collider.isTrigger = true;
            enemyFileName = obj.GetStringProperty("EnemyFileName");
            Console.WriteLine(enemyFileName);


            enemyAnimation = new AnimationSprite("Enemies/" + enemyFileName, 5, 1, -1, false);
            enemyAnimation.SetOrigin(this.x + this.width / 2, this.y + this.width / 2 + 3);
            AddChild(enemyAnimation);
        }

        void Update()
        {
            enemyAnimation.SetCycle(1, 4);
            enemyAnimation.Animate(0.1f);
            VerticalMovement();
        }

        void VerticalMovement()
        {
            
            if (MoveUntilCollision(0, fallingSpeed) != null)
            {
                fallingSpeed = 0;
            }
            else
            {
                fallingSpeed += 1;
            }
        }
    }
}
