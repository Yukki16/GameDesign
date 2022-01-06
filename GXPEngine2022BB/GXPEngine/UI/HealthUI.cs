using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HealthUI : GameObject
    {
        private Sprite fullHeart;
        private Sprite halfHeart;
        private Sprite noHeart;

        private SpriteBatch health = new SpriteBatch;

        Player player;

        private int HP;
        public HealthUI(Player p)
        {
            fullHeart = new Sprite("UI/HP/Player/heart_full_16x16.png");
            halfHeart = new Sprite("UI/HP/Player/heart_half_16x16.png");
            noHeart = new Sprite("UI/HP/Player/heart_empty_16x16.png");

            player = p;
            HP = player.returnHP();
            
            for(int i = 0; i < HP / 2; i++)
            {
                health.AddChild(fullHeart);
                
            }

            this.AddChild(health);
        }

        
    }
}
