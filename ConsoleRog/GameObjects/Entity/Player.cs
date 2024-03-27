using ConsoleRog.Core;
using ConsoleRog.GameObjects.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects.Entity
{
    public class Player: Entity
    {
        private readonly Vector2 finish;
        private GameObjectManager gameObjectManager;
        public bool finished {  get; private set; }
        public Player(string symbol, Vector2 position, Vector2 finish, GameObjectManager gameObjectManager, MapObject[,] mapObjects, int hp = 100, bool isSolid = true) : 
            base(symbol, position, mapObjects, hp, isSolid)
        {
            this.finish= finish;
            this.gameObjectManager = gameObjectManager;
            finished = false;
        }

        public void Update(Vector2 _newPosition)
        {
            DrawMyself(" ", position);
            position = _newPosition;
            DrawMyself(symbol, position);
        }

        public virtual void Move(int a)
        {
            Vector2 newPosition;

            switch (a)
            {
                case 1:
                    newPosition = position + Vector2.Up;
                    break;
                case 2:
                    newPosition = position + Vector2.Down;
                    break;
                case 3:
                    newPosition = position + Vector2.Left;
                    break;
                case 4:
                    newPosition = position + Vector2.Right;
                    break;
                case 5:
                    Attack();
                    newPosition = position;
                    break;
                default:
                    return;
            }

            if (mapObjects[newPosition.X, newPosition.Y].isSolid == false)
            {
                Update(newPosition);
                if (newPosition.X == finish.X && newPosition.Y == finish.Y)
                {
                    finished = true;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            hp = hp - damage;
            if (hp <= 0)
            {
                hp = 0;
            }
        }

        public void Attack()
        {
            foreach (Enemy enemy in gameObjectManager.GetAllEnemys())
            {
                if (enemy.IsPlayerNext(position))
                {
                    enemy.TakeDamage();
                }
            }
        }
    }
}
