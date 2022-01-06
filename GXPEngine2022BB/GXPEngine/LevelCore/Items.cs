using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Items : AnimationSprite
    {
        public int addHp;
        public int addDamage;
        public Items(int itemNr) : base("Items/items.png", 13, 15, -1, false, true)
        {
            //Console.WriteLine("item");
            this.SetCycle(itemNr, 1);
            this.collider.isTrigger = true;
            AddStats(itemNr);
        }

        public Items(TiledObject obj) : base("Items/items.png", 13, 15, -1, false, true)
        {
            this.SetCycle(obj.GetIntProperty("ItemNumber"), 1);
            this.collider.isTrigger = true;
            AddStats(obj.GetIntProperty("ItemNumber"));
        }

        private void AddStats(int itemNr)
        {
            if (itemNr > 85 && itemNr < 117)
                addDamage = 1;
        }
    }
}
