using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class LabelObjectFactory : GameObjectFactory
    {
        private static int CurrentInd = -1;

        public LabelObjectFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }
        public override GameObject CreateGameObject(GameObjectLocation location)
        {
            CurrentInd++;
            return new LabelObject()
            {
                Figure = gameSettings.LabelStatrString[CurrentInd],
                Location = location,
                ObjectType = GameObjectType.LabelObject
            };
        }
        public List<GameObject> GetStartString()
        {
            List<GameObject> startString = new List<GameObject>();
            for (int i = 0; i < gameSettings.LabelStatrString.Length; i++)
            {
                startString.Add(CreateGameObject(new GameObjectLocation() { X = gameSettings.LabelStartXCoordinate + i, Y = gameSettings.LabelStartYCoordinate }));
            }
            return startString;
        }
    }
}
