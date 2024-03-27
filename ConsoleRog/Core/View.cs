using ConsoleRog.GameObjects;
using ConsoleRog.GameObjects.Entity;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.MapCore;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleRog.Core
{
    public class View
    {
        private readonly GameObject[,] gameObjects;
        private readonly int mapWidth, mapHeight;
        private Player player;

        public View(GameObject[,] gameObjects, int mapWidth, int mapHeight, Player player)
        {
            this.gameObjects = gameObjects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.player = player;
            DrawMap();
        }

        private void DrawMap()
        {
            Console.Clear();
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Console.Write(gameObjects[x, y].symbol);
                }
                Console.Write("\n");
            }
            Console.WriteLine("Press F for attack");
            ConsoleHelper.WriteToBufferAt(player.symbol, player.position.X, player.position.Y);
        }

        public void DrawEnemys(List<Entity> enemyObjects)
        {
            foreach (Enemy enemy in enemyObjects)
            {
                ConsoleHelper.WriteToBufferAt(enemy.symbol, enemy.position.X, enemy.position.Y);
            }
        }

        public void RemoweEnemys(List<Entity> enemyObjects)
        {
            foreach (Enemy enemy in enemyObjects)
            {
                ConsoleHelper.WriteToBufferAt(gameObjects[enemy.position.X, enemy.position.Y].symbol, enemy.position.X, enemy.position.Y);
            }
        }
    }
}
