using System;
using System.Collections.Generic;

namespace Spave_Invaders_v0_01
{
    internal class AlienShipFactory : GameObjectFactory
    {
        private static Random random = new Random();
        public AlienShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }
        public override GameObject CreateGameObject(GameObjectLocation location)
        {
            return new AlienShip()
            {
                Figure = gameSettings.AlienShip,
                Location = location,
                ObjectType = GameObjectType.AlienShip
            };
           
        }
        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();
            
            int startX = gameSettings.SwarmStartXCoordinate;
            int startY = gameSettings.SwarmStartYCoordinate;

            //for (int i = 0; i < gameSettings.AmountOfSwarmsRows; i++)
            //    for (int j = 0; j < gameSettings.AmountOfSwarmsCols; j++)
            for (int i = 0; i < 21; i++)
                    swarm.Add(CreateGameObject(new GameObjectLocation() { X =/*startX +*/random.Next(1,48), Y =2/*startY+ i*/ }));
            
            return swarm;
        }
        public GameObject GetNewAlienShip()
        {
            return CreateGameObject(new GameObjectLocation() { X =/*startX +*/random.Next(1, 48), Y = 2/*startY+ i*/ });
        }
    }
}
