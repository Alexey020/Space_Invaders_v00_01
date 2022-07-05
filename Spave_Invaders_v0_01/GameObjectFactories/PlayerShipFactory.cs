using System;
using System.Collections.Generic;

namespace Spave_Invaders_v0_01
{
    internal class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings)
            : base(gameSettings){}
        public override GameObject CreateGameObject(GameObjectLocation location)
        {
            return new PlayerShip() { Figure = gameSettings.PlayerShip, Location = location, ObjectType = GameObjectType.PlayerShip };
        }
        public GameObject GetPlayerShip()
        {
            return CreateGameObject(new GameObjectLocation() { X = gameSettings.PlayerShipStartXCoordinate, Y = gameSettings.PlayerShipStartYCoordinate });
        }
    }
}
