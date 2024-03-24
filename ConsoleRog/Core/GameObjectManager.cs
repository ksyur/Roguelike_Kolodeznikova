using ConsoleRog.GameObjects.Entity;
using ConsoleRog.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;

namespace ConsoleRog.Core
{
    public class GameObjectManager
    {
        private readonly MapObject[,] map;
        private readonly int mapWidth, mapHeight;
        private Random random = Random.Shared;
        private View gameView;
        private readonly Vector2 finish;
        public List<Enemy> enemyObjects { get; private set; }

        public GameObjectManager(MapObject[,] map, int mapWidth, int mapHeight, View gameView, Vector2 finish)
        {
            this.map = map;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.gameView = gameView;
            this.finish = finish;
            enemyObjects = new List<Enemy>();
            CreateEntities();
        }

        private void CreateEntities()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 position = GetStartPosition();
                Enemy enemy = new Enemy("Z", position, 50, gameView.mapData, mapHeight, mapWidth, finish);
                enemyObjects.Add(enemy);
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Vector2 position = GetStartPosition();
            //    Shooter shooter = new Shooter("S", position, 50, gameView.mapData, mapHeight, mapWidth, finish);
            //    enemyObjects.Add(shooter);
            //}
        }

        private Vector2 GetStartPosition()
        {
            while (true)
            {
                int x = random.Next(2, mapWidth);
                int y = random.Next(2, mapHeight);
                if (map[x, y].isSolid == false && x != finish.X && y != finish.Y)
                {
                    Vector2 pos = new Vector2(x, y);
                    return pos;
                }
            }
        }

        public GameObject[,] GetAllObjects()
        {
            GameObject[,] objects = new GameObject[mapWidth, mapHeight];
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    objects[x, y] = new GameObject(map[x, y].symbol, map[x, y].position, map[x, y].isSolid);
                }
            }
            foreach (Enemy enemy in enemyObjects)
            {
                objects[enemy.position.X, enemy.position.Y] = new GameObject(enemy.symbol, enemy.position, enemy.isSolid);
            }
            return objects;
        }
    }
}
