using System;
using System.Threading;

namespace Spave_Invaders_v0_01
{
    internal class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static UIController _UIController;
        
        static void Main(string[] args)
        {
            Initialize();

            gameEngine.Run();

        }
        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            _UIController = new UIController();

            _UIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            _UIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            _UIController.OnSpacebarPressed += (obj, arg) => gameEngine.Shoot();

            Thread UIThread =new Thread( _UIController.ButtonPreassing);
            UIThread.Start();

            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }
    }
}
