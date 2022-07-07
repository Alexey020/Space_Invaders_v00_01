using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class Scene
    {
        public List<GameObject> swarm {get;set;}
        public List<GameObject> ground {get;set;}
        public GameObject playerShip {get;set;}
        public List<GameObject> playerShipMissile { get; set; }
        public string statusBar { get; set; }
        
        
        private GameSettings gameSettings;
        

        private static Scene scene;
        private Scene()
        {
        }

        private Scene(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            swarm = new AlienShipFactory(gameSettings).GetSwarm();
            ground = new GroundFactory(gameSettings).GetGround();
            playerShip = new PlayerShipFactory(gameSettings).GetPlayerShip();
            playerShipMissile = new List<GameObject>();
            statusBar = " score 0 lavel 0";

        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (scene == null)
            {
                scene = new Scene(gameSettings);
            }
            
                return scene;
        }
        public void Reset()
        {
            swarm = new AlienShipFactory(gameSettings).GetSwarm();
            ground = new GroundFactory(gameSettings).GetGround();
            playerShip = new PlayerShipFactory(gameSettings).GetPlayerShip();
            playerShipMissile = new List<GameObject>();
            statusBar = " score 0 lavel 0";
        }
    }
}
