using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class GameSettings
    {
        public int ConsoleWidth { get; set; } = 50;
        public int ConsoleHeight { get; set; } = 35;
        
        //-------------------------------------------
        
        public int AmountOfSwarmsRows { get; set; } = 2;
        public int AmountOfSwarmsCols { get; set; } = 30;

        public int SwarmStartXCoordinate { get; set; } = 15;
        public int SwarmStartYCoordinate { get; set; } = 2;

        public char AlienShip { get; set; } = 'W';


        public int SwarmSpeed { get; set; } = 13;

        //-------------------------------------------

        public int PlayerShipStartXCoordinate { get; set; } = 30;
        public int PlayerShipStartYCoordinate { get; set; } = 28;

        public char PlayerShip { get; set; } = 'H';

        //-----------------------------------------------
        public int AmountOfGrounfRows { get; set; } = 1;
        public int AmountOfGroundCols { get; set; } = 48;

        public int GroundStartXCoordinate { get; set; } = 1;
        public int GroundStartYCoordinate { get; set; } = 29;

        public char Ground { get; set; } = 'x';

        //----------------------------------------------------

        public char PlayerMissile { get; set; } = (char)4;
        public int PlayerMissileSpeed { get; set; } = 5;

        //--------------------------------------------------

        public int StatusStringStartXCoordinate { get; set; } = 3;
        public int StatusStringStartYCoordinate { get; set; } = 33;

        public int GameSpeed { get; set; } = 100;
    }
}
