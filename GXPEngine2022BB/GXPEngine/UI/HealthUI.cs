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

        private Pivot health = new Pivot();

        Player player;

        private int HP;
        public HealthUI(Player p)
        {
            fullHeart = new Sprite("UI/HP/Player/heart_full_16x16.png");
            halfHeart = new Sprite("UI/HP/Player/heart_half_16x16.png");
            noHeart = new Sprite("UI/HP/Player/heart_empty_16x16.png");

            player = p;
            HP = player.returnHP();

            for (int i = 0; i < HP / 2; i++)
            {
                health.AddChild(new Sprite("UI/HP/Player/heart_full_16x16.png"));
            }

            List<GameObject> children = health.GetChildren();


            int j = 0;
            foreach (GameObject child in children)
            {
                child.SetXY(j * fullHeart.width, 0);
                j++;
            }

            this.AddChild(health);
        }


    }
}
