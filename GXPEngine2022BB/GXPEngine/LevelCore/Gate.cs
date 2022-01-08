using GXPEngine.Core;
using GXPEngine.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Gate : Sprite
    {
        AnimationSprite closedPortal;
        AnimationSprite openPortal;

        Player player;
        SceneManager sceneManager;
        public Boolean portalopened = false;

        public Gate(TiledObject obj) : base(new Texture2D(32,32))
        {
            this.collider.isTrigger = true;
            closedPortal = new AnimationSprite("Terrain/portalRings1.png", 4, 5, -1, false, false);
            closedPortal.SetXY(-this.width / 2, -this.height/2);
            closedPortal.SetCycle(0, 17);
            //closedPortal.Animate();
            //closedPortal.collider.isTrigger = true;
            this.AddChild(closedPortal);

            openPortal = new AnimationSprite("Terrain/portalRings2.png", 5, 1, -1, false, false);
            openPortal.SetXY(-this.width / 2, -this.height / 2);

            sceneManager = game.FindObjectOfType<SceneManager>();
            //Console.WriteLine(sceneManager == null);
        }

        private void Update()
        {
            if (!portalopened)
                closedPortal.Animate(0.2f);
            else
                openPortal.Animate(0.2f);
        }
        public void AddPlayer(Player p)
        {
            player = p;
        }

        public void OpenThePortal()
        {
            this.RemoveChild(closedPortal);
            this.AddChild(openPortal);
            portalopened = true;
        }

        public void FinishLevel()
        {
            sceneManager.LoadLevel("LevelSelecter");
        }
    }
}
