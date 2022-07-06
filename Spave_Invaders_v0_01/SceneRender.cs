using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class SceneRender
    {
        private int screenWidth;
        private int screenHight;

        private char[,] screenMatrix;

       // private static SceneRender sceneRender;

        public SceneRender(GameSettings gameSettings)
        {
            //if (sceneRender == null){            }

            screenHight = gameSettings.ConsoleHeight-4 ;
            screenWidth = gameSettings.ConsoleWidth+1;

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            screenMatrix = new char[screenHight, screenWidth];

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            Console.SetCursorPosition(0, 0);

            AddListForRenndering(scene.ground);
            AddListForRenndering(scene.swarm);
            AddListForRenndering(scene.playerShipMissile);
            AddGameObjectToRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < screenMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < screenMatrix.GetLength(1); x++)
                {
                    stringBuilder.Append(screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            stringBuilder.Append("\n    " + scene.statusBar);
            Console.WriteLine(stringBuilder.ToString());
            screenMatrix = new char[screenHight, screenWidth];

            Console.SetCursorPosition(0, 0);

        }
        
        public void AddGameObjectToRendering(GameObject gameObject)
        {
          //  if (gameObject.Location.X<screenMatrix.GetLength(0) 
            //  && gameObject.Location.Y<screenMatrix.GetLength(1) )
            {
                screenMatrix[gameObject.Location.Y, gameObject.Location.X] = gameObject.Figure;
            }
            //else
            {
                //screenMatrix[gameObject.Location.Y, gameObject.Location.X] = ' ';
            }
        }
        public void AddListForRenndering(List<GameObject> gameObjects)
        {
            foreach (GameObject item in gameObjects)
                AddGameObjectToRendering(item);
        }
        public void RenderGameOver()
        {
            Console.SetCursorPosition(13, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
