using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;


namespace GXPEngine
{
    class Player : Sprite
    {

        private Boolean isWalking = false;
        private Boolean isJumping = true;
        private Boolean canJump = false;
        private Boolean isRunning = false;
        private Boolean isAttacking = false;
        private Boolean gotDamaged = false;

        //private Boolean isStanding = false;

        private int walkingSpeed = 3;
        private float fallingSpeed = 0;
        private int runningSpeed = 6;
        private float attackTimer = 0f;
        private float takeDamageTimer = 0f;

        private String characterName;

        private int HP = 6;
        private int damage = 1;

        private AnimationSprite animations;

        private Sprite attackHitBox = new Sprite("2 GraveRobber/AttackHitBox.png");

        //private Level1 level1 = new Level1();
        /*public Player(TiledObject obj) : base ("SteamMan.png")
        {
            Console.WriteLine("here");
        }*/


        public Player(TiledObject obj) : base(new Texture2D(15,32))
        {
            this.collider.isTrigger = true;

            animations = new AnimationSprite("2 GraveRobber/GraveRobber_spritesheet.png", 6, 5, -1, false, false);
            //Console.WriteLine(animations.width);
            AddChild(animations);
            SetOrigin(width / 2, height / 2);
            animations.SetOrigin(animations.width / 2, animations.height / 2 + 8);

            attackHitBox.collider.isTrigger = true;
            attackHitBox.SetOrigin(0, this.y + this.height / 2);
            animations.AddChild(attackHitBox);

        }

        public void Update()
        {
            PlayerAnimations();
            HorizontalMovement();
            VerticalMovement();
            Attack();
            GetHurt();
        }

        private void PlayerAnimations()
        {
            if (!isWalking && !isRunning && !isJumping && !isAttacking)
            {
                animations.SetCycle(6, 4);
                animations.Animate(0.06f);
            }
            else if (isJumping)
            {
                if (fallingSpeed < 0) // goes up and make the jump animation
                {
                    animations.SetCycle(12, 4);

                    animations.Animate(0.05f);
                }
                else // falls down animation
                {
                    animations.SetCycle(16, 1);

                    animations.Animate(0.02f);
                }


            }
            else if (isAttacking)
            {
                animations.SetCycle(0, 6);
                animations.Animate(0.1f);
                DamageEnemy();
            }
            else if (isWalking)
            {
                animations.SetCycle(24, 6);
                animations.Animate(0.15f);
            }
            else if (isRunning)
            {
                animations.SetCycle(18, 6);
                animations.Animate(0.15f);
            }
        }

        void HorizontalMovement()
        {
            float xSpeed = 0;

            // Needs refactoring!!!

            if (Input.GetKey(Key.D) && Input.GetKey(Key.LEFT_SHIFT) && !isAttacking)
            {
                isWalking = false;
                xSpeed += runningSpeed;
                animations.Mirror(false, false);
                if (attackHitBox.x < 0)
                    attackHitBox.x = attackHitBox.x + attackHitBox.width;
                isRunning = true;
            }
            else if (Input.GetKey(Key.D) && !isRunning && !isAttacking)
            {
                xSpeed += walkingSpeed;
                animations.Mirror(false, false);
                if (attackHitBox.x < 0)
                    attackHitBox.x = attackHitBox.x + attackHitBox.width;
                isWalking = true;
            }

            if (Input.GetKey(Key.A) && Input.GetKey(Key.LEFT_SHIFT) && !isAttacking)
            {
                isWalking = false;
                xSpeed -= runningSpeed;
                animations.Mirror(true, false);
                if(attackHitBox.x > - attackHitBox.width)
                    attackHitBox.x = attackHitBox.x - attackHitBox.width;
                isRunning = true;
            }
            else if (Input.GetKey(Key.A) && !isRunning && !isAttacking)
            {
                xSpeed -= walkingSpeed;
                animations.Mirror(true, false);
                if (attackHitBox.x > -attackHitBox.width)
                    attackHitBox.x = attackHitBox.x - attackHitBox.width;
                isWalking = true;
            }

            if (Input.GetKeyUp(Key.A) || Input.GetKeyUp(Key.D)) //after releasing either of them it stops running/walking
            {
                isWalking = false;
                isRunning = false;
                //xSpeed = 0;
            }
            MoveUntilCollision(xSpeed, 0);
            //this.x += xSpeed;
        }

        void VerticalMovement()
        {
            fallingSpeed += 1;

            if (Input.GetKeyDown(Key.SPACE) && canJump)
            {
                fallingSpeed = -15;
                isJumping = true;
                canJump = false;
            }

            if (MoveUntilCollision(0, fallingSpeed) != null)
            {
                fallingSpeed = 0;
                isJumping = false;
                canJump = true;
            }
            if (fallingSpeed > 0)
            {
                isJumping = true;
                canJump = false;
            }
        }

        void Attack()
        {
            if (Input.GetMouseButtonDown(0) && Time.time - attackTimer > 1000)
            {
                isAttacking = true;
                attackTimer = Time.time;
            }
            else if (Time.time - attackTimer > 1000)
            {
                isAttacking = false;
            }
        }

        private void DamageEnemy()
        {
            GameObject[] objects = attackHitBox.GetCollisions(true, false);
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is Enemy)
                {
                    Enemy enemy = objects[i].FindObjectOfType<Enemy>();
                    if (!enemy.gotDamaged)
                    {
                        enemy.LowerHP(damage);
                        enemy.gotDamaged = true;
                        enemy.damagedTimer = Time.time;
                    }
                }
            }
        }

        void GetHurt()
        {
            GameObject[] objects = this.GetCollisions(true, false);
            for (int i = 0; i < objects.Length; i++)
            {
                if(objects[i] is Enemy && !gotDamaged) 
                {
                    HP--;
                    gotDamaged = true;
                    takeDamageTimer = Time.time;
                    //Console.WriteLine(takeDamageTimer);
                }
            }

            if(gotDamaged == true && Time.time - takeDamageTimer < 1000)
            {
                animations.SetColor(Mathf.Sin(Time.time / 100.0f), 0, 0);
                
            }
            else
            {
                gotDamaged = false;
                animations.SetColor(1, 1, 1);
            }
        }
        
    }


}
