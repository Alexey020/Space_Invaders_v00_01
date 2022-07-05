using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            : base(gameSettings){}
        public override GameObject CreateGameObject(GameObjectLocation location)
        {

            return new PlayerShipMissile()
            {
                Figure = gameSettings.PlayerMissile,
                Location = new GameObjectLocation() { X = location.X,Y = location.Y-1},
                ObjectType = GameObjectType.PlayerShipMissile
            };
        }
    }
}
