using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class GameEngine
    {
        private bool isNotOver;
        private ConsoleKeyInfo key;
        private static GameEngine gameEngine;
        private SceneRender sceneRender;
        private GameSettings gameSettings;
        private int score = 0;
        private int lavel = 0;

        private Scene scene;

        private GameEngine()
        {
            
        }
        public GameEngine(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            isNotOver = true;
            scene = Scene.GetScene(gameSettings);
            sceneRender = new SceneRender(gameSettings);
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (gameEngine ==  null)
            {
                gameEngine = new GameEngine(gameSettings);
            }
            return gameEngine;
        }
        public void Run()
        {
            StartAgain:
            int swarmMoveChecker= 0;
            do
            {
                //Console.Clear();
                sceneRender.Render(scene);
                Thread.Sleep(gameSettings.GameSpeed);

                if (swarmMoveChecker == gameSettings.SwarmSpeed)
                {
                    MoveSwarm();
                    swarmMoveChecker = 0;
                }
                MoveMissile();
                swarmMoveChecker++;
            } while (isNotOver);
                sceneRender.RenderGameOver();

            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.P)
            {
                Console.Clear();
                scene.Reset();
                isNotOver = true;
                goto StartAgain;
            }


        }
        public void CalculateMovePlayerShipLeft()
        {
            if (scene.playerShip.Location.X > 1)
            {
                scene.playerShip.Location.X--;
            }
        }
        public void CalculateMovePlayerShipRight()
        {
            if (scene.playerShip.Location.X < gameSettings.ConsoleWidth-1)
            {
                scene.playerShip.Location.X++;
            }
        }

        public void MoveSwarm()
        {
            for (int i = 0; i < scene.swarm.Count; i++)
            {
                for (int q = 0; q < scene.ground.Count; q++)
                {
                    if (scene.swarm[i].Location.Y == scene.ground[q].Location.Y
                        && scene.swarm[i].Location.X == scene.ground[q].Location.X)
                    {
                        scene.swarm.RemoveAt(i);
                        scene.ground.RemoveAt(q);
                        break;
                    }
                }
            }
            foreach (var item in scene.swarm)
            {
                item.Location.Y++;
               
                if (item.Location.Y >= 31)
                {
                    isNotOver = false; 
                }
            }
            
        }
        public void Shoot()
        {
            PlayerShipMissileFactory playerShipMissileFactory = new PlayerShipMissileFactory(gameSettings);
            GameObject missile = playerShipMissileFactory.CreateGameObject(scene.playerShip.Location);
            scene.playerShipMissile.Add(missile);
            Console.Beep();
        }
        public void MoveMissile()
        { 
            //Again:
            for (int i = 0; i < scene.playerShipMissile.Count; i++)
            {
                if (scene.playerShipMissile[i].Location.Y <= 2)
                {
                    scene.playerShipMissile.RemoveAt(i);
                    break;
                }
                
                for (int q = 0; q < scene.swarm.Count; q++)
                {
                    if (scene.playerShipMissile[i].Location.Y == scene.swarm[q].Location.Y
                        && scene.playerShipMissile[i].Location.X == scene.swarm[q].Location.X)
                    {
                        scene.swarm.RemoveAt(q);
                        scene.playerShipMissile.RemoveAt(i);
                        score++;
                        if (score>=10)
                        {
                            score = 0;
                            lavel++;
                        }
                        scene.statusBar = "score - " + score + " lavel - " + lavel;
                        scene.swarm.Add(new AlienShipFactory(gameSettings).GetNewAlienShip());
                        break;// goto Again;
                    }
                }
            }
            foreach (var item in scene.playerShipMissile)
            {
                item.Location.Y--;
            }  
        }
    }
}
