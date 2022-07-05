using System;

namespace Spave_Invaders_v0_01
{
    abstract class GameObjectFactory
    {
        public GameSettings gameSettings { get; set; }

        public abstract GameObject CreateGameObject(GameObjectLocation location);

        public GameObjectFactory(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }
    }
}
