using ConsoleRog.GameObjects.Entity;
using ConsoleRog.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.Core
{
    public class GameObjectManager
    {
        private Random random = Random.Shared;
        private readonly int mapWidth, mapHeight;
        private readonly MapObject[,] mapObjects;
        private readonly Vector2 finish;

        public Player player { get; private set; }
        public List<Entity> enemyObjects { get; private set; }

        public GameObjectManager(int mapWidth, int mapHeight, MapObject[,] mapObjects, Vector2 finish)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.mapObjects = mapObjects;
            this.finish = finish;
            enemyObjects = new List<Entity>();
            CreateEntities();
        }

        public void Update()
        {
            foreach (Enemy enemy in GetAllEnemys())
            {
                enemy.Update(player);
                if (enemy.hp <= 0)
                {
                    RemoveEnemy(enemy);
                }
            }
        }

        private void CreateEntities()
        {
            for (int i = 0; i < 35; i++)
            {
                Enemy enemy = new Enemy("Z", GetStartPosition(), mapObjects, 100, mapHeight, mapWidth);
                enemyObjects.Add(enemy);
            }
            for (int i = 0; i < 15; i++)
            {
                Shooter shooter = new Shooter("S", GetStartPosition(), mapObjects, 100, mapHeight, mapWidth);
                enemyObjects.Add(shooter);
            }
            player = new Player("P", new Vector2(1, 1), finish, this, mapObjects);
        }

        private Vector2 GetStartPosition()
        {
            while (true)
            {
                int x = random.Next(1, mapWidth);
                int y = random.Next(1, mapHeight);
                if (mapObjects[x, y].isSolid == false)
                {
                    Vector2 pos = new Vector2(x, y);
                    return pos;
                }
            }
        }

        private void RemoveEnemy(Enemy enemy)
        {
            enemyObjects.Remove(enemy);
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
