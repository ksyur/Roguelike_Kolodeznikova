﻿using ConsoleRog.GameObjects.Entity;
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
        private Vector2 finish;

        public Player player { get; private set; }
        public List<Enemy> enemyObjects { get; private set; }

        public GameObjectManager(int mapWidth, int mapHeight, MapObject[,] mapObjects, Vector2 finish)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.mapObjects = mapObjects;
            this.finish = finish;
            enemyObjects = new List<Enemy>();
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
            for (int i = 0; i < 10; i++)
            {
                Vector2 position = GetStartPosition();
                Enemy enemy = new Enemy("Z", position, 100, mapObjects, mapHeight, mapWidth);
                enemyObjects.Add(enemy);
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Vector2 position = GetStartPosition();
            //    Shooter shooter = new Shooter("S", position, 50, gameView.mapData, mapHeight, mapWidth, finish);
            //    enemyObjects.Add(shooter);
            //}
            player = new Player("P", new Vector2(1, 1), mapObjects, finish, this);
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

        private void RemoveEnemy(Enemy enemy)
        {
            enemyObjects.Remove(enemy);
        }

        public List<Enemy> GetAllEnemys()
        {
            List<Enemy> objects = new List<Enemy>();
            foreach (Enemy enemy in enemyObjects)
            {
                objects.Add(enemy);
            }
            return objects;
        }
    }
}
