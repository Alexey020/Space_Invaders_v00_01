using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    abstract class GameObject
    {
        public GameObjectLocation Location { get; set; }
        public char Figure { get; set; }
        public GameObjectType ObjectType { get; set; }
    }
}
