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
        private readonly int mapWidth, mapHeight;
        private Random random = Random.Shared;
        private readonly MapObject[,] mapObjects;
        public List<Enemy> enemyObjects { get; private set; }

        public GameObjectManager(int mapWidth, int mapHeight, MapObject[,] mapObjects)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.mapObjects = mapObjects;
            enemyObjects = new List<Enemy>();
            CreateEntities();
        }

        private void CreateEntities()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 position = GetStartPosition();
                Enemy enemy = new Enemy("Z", position, 50, mapObjects, mapHeight, mapWidth);
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
                if (mapObjects[x, y].isSolid == false)
                {
                    Vector2 pos = new Vector2(x, y);
                    return pos;
                }
            }
        }

        public List<Entity> GetAllEnemys()
        {
            List<Entity> objects = new List<Entity>();
            foreach (Enemy enemy in enemyObjects)
            {
                objects.Add(enemy);
            }
            return objects;
        }
    }
}
