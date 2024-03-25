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
        private readonly MapObject[,] mapObjects;
        private int mapWidth, mapHeight;
        private Player player;

        public View(MapObject[,] mapObjects, int mapWidth, int mapHeight, Player player)
        {
            this.mapObjects = mapObjects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.player = player;
            DrawMap();
            ConsoleHelper.WriteToBufferAt(player.symbol, player.position.X, player.position.Y);
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Console.Write(mapObjects[x, y].symbol);
                }
                Console.Write("\n");
            }
        }

        public void DrawEnemys(List<Enemy> enemyObjects)
        {
            foreach (Enemy enemy in enemyObjects)
            {
                ConsoleHelper.WriteToBufferAt(enemy.symbol, enemy.position.X, enemy.position.Y);
            }
        }

        public void RemoweEnemys(List<Enemy> enemyObjects)
        {
            foreach (Enemy enemy in enemyObjects)
            {
                ConsoleHelper.WriteToBufferAt(mapObjects[enemy.position.X, enemy.position.Y].symbol, enemy.position.X, enemy.position.Y);
            }
        }

        private void DrawInfoPanel()
        {
            var infoBuilder = new StringBuilder(30);
            if (player.hp > 0)
            {
                infoBuilder.Append($"Health: {player.hp}  Punch: Press 'E'");
            }
            string info = infoBuilder.ToString();
            
        }
    }
}
