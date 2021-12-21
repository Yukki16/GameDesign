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
        private float fallingSpeed = 0;

        public Boolean gotDamaged = false;
        public float damagedTimer = 0f;

        private int HP = 3;
        private int xSpeed = 1;
        

        AnimationSprite enemyAnimation;
        public Enemy(TiledObject obj) : base("Enemies/Debug.png")
        {
            SetOrigin(width / 2, height / 2);
            this.alpha = 0;

            this.collider.isTrigger = true;
            enemyFileName = obj.GetStringProperty("EnemyFileName");
            Console.WriteLine(enemyFileName);


            enemyAnimation = new AnimationSprite("Enemies/" + enemyFileName, 5, 1, -1, false, false);
            enemyAnimation.SetOrigin(this.x + this.width / 2, this.y + this.width / 2 + 3);
            AddChild(enemyAnimation);
            //Console.WriteLine(parent.FindObjectsOfType<Waypoint>());
        }

        void Update()
        {
            enemyAnimation.SetCycle(1, 4);
            enemyAnimation.Animate(0.1f);
            VerticalMovement();
            if (!gotDamaged)
            {
                HorizontalMovement();
            }
            else
            {
                ResumeMovement();
            }


            DestroyEnemy();
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

        void HorizontalMovement()
        {
            if (MoveUntilCollision(xSpeed, 0) != null)
            {
                xSpeed *= -1;
                if (xSpeed < 0)
                {
                    enemyAnimation.Mirror(true, false);
                }
                else
                {
                    enemyAnimation.Mirror(false, false);
                }
            }
        }

        void DestroyEnemy()
        {
            if (HP == 0)
                this.LateDestroy();
        }

        public void LowerHP(int damage)
        {
            HP -= damage;
        }

        void ResumeMovement()
        {
            if (Time.time - damagedTimer > 1000)
            {
                gotDamaged = false;
                Console.WriteLine(Time.time - damagedTimer);
            }
        }
    }
}
