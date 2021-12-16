﻿using GXPEngine.Core;
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
        //private Boolean isStanding = false;

        private int walkingSpeed = 3;
        private float fallingSpeed = 0;
        private int runningSpeed = 6;
        private float attackTimer = 0f;

        private String characterName;

        private int HP = 6;
        private int damage = 1;

        private AnimationSprite animations;

        //private Level1 level1 = new Level1();
        /*public Player(TiledObject obj) : base ("SteamMan.png")
        {
            Console.WriteLine("here");
        }*/

        
        public Player(TiledObject obj) : base(new Texture2D(15,32)) {

            animations = new AnimationSprite("2 GraveRobber/GraveRobber_spritesheet.png", 6, 5, -1, false, false);
            Console.WriteLine(animations.width);
            AddChild(animations);
            SetOrigin(width/2,height/2);
            animations.SetOrigin(animations.width/2, animations.height/2 + 8);
        }
        
        public void Update()
        {
          
            if (!isWalking && !isRunning && !isJumping && !isAttacking)
            {
                animations.SetCycle(6, 4);
                animations.Animate(0.08f);
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

                
            }else if(isAttacking)
            {
                animations.SetCycle(0, 6);
                animations.Animate(0.1f);
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
            HorizontalMovement();
            VerticalMovement();
            Attack();
        }

        void HorizontalMovement()
        {
            float xSpeed = 0;


            if (Input.GetKey(Key.D) && Input.GetKey(Key.LEFT_SHIFT) && !isAttacking)
            {
                isWalking = false;
                xSpeed += runningSpeed;
                animations.Mirror(false, false);
                //Mirror(false, false);
                isRunning = true;
            }
            else if (Input.GetKey(Key.D) && !isRunning && !isAttacking)
            {
                xSpeed += walkingSpeed;
                animations.Mirror(false, false);
                //Mirror(false, false);
                isWalking = true;
            }

            if (Input.GetKey(Key.A) && Input.GetKey(Key.LEFT_SHIFT) && !isAttacking)
            {
                isWalking = false;
                xSpeed -= runningSpeed;
                animations.Mirror(true, false);
                //Mirror(true, false);
                isRunning = true;
            }
            else if (Input.GetKey(Key.A) && !isRunning && !isAttacking)
            {
                xSpeed -= walkingSpeed;
                animations.Mirror(true, false);
                //Mirror(true, false);
                isWalking = true;
            }

            if (Input.GetKeyUp(Key.A) || Input.GetKeyUp(Key.D))
            {
                isWalking = false;
                isRunning = false;
                //xSpeed = 0;
            }
            MoveUntilCollision(xSpeed, 0);
        }

        void VerticalMovement()
        {
            fallingSpeed += 1;

            if (Input.GetKeyDown(Key.SPACE) && canJump)
            {
                fallingSpeed = -18;
                isJumping = true;
                canJump = false;
            }

            if (MoveUntilCollision(0, fallingSpeed) != null)
            {
                fallingSpeed = 0;
                isJumping = false;
                canJump = true;
            }
        }

        void Attack()
        {
            if (Input.GetMouseButtonDown(0) && Time.time - attackTimer > 1000)
            {
                isAttacking = true;
                attackTimer = Time.time;
            }
            else if(Time.time - attackTimer > 1000)
            {
                isAttacking = false;
            }
        }
        
    }

    
}
