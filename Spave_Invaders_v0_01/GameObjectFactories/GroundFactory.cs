using System;
using System.Collections.Generic;

namespace Spave_Invaders_v0_01
{
    internal class GroundFactory : GameObjectFactory
    {

        public GroundFactory(GameSettings gameSettings)
            : base(gameSettings){}
        public override GameObject CreateGameObject(GameObjectLocation location)
        {
            return new GroundObject() { Figure = gameSettings.Ground, Location = location, ObjectType = GameObjectType.GroundObject };
        }
        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();

            int startX = gameSettings.GroundStartXCoordinate;
            int startY = gameSettings.GroundStartYCoordinate;

            for (int i = 0; i < gameSettings.AmountOfGrounfRows; i++)
                for (int j = 0; j < gameSettings.AmountOfGroundCols; j++)
                    ground.Add(CreateGameObject(new GameObjectLocation() { X = startX + j, Y = startY + i }));

            return ground;
        }
    }
}
