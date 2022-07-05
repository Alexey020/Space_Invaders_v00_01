using System;
using System.Collections.Generic;

namespace Spave_Invaders_v0_01
{
    internal class AlienShipFactory : GameObjectFactory
    {
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

            for (int i = 0; i < gameSettings.AmountOfSwarmsRows; i++)
                for (int j = 0; j < gameSettings.AmountOfSwarmsCols; j++)
                    swarm.Add(CreateGameObject(new GameObjectLocation() { X =startX+ j, Y =startY+ i }));

            return swarm;
        }
    }
}
