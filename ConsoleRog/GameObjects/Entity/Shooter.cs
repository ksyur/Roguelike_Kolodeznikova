using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleRog.GameObjects.Entity
{
    public class Shooter: Enemy
    {
        private Random random = Random.Shared;
        private int attackDirection;
        private int direction;
        public Shooter(string symbol, Vector2 position, MapObject[,] mapObjects, int hp, bool isSolid = true)
           : base(symbol, position, mapObjects, hp, isSolid)
        {
            DrawMyself(symbol, position);
        }
        public override void Update(Player player)
        {
            Move(player);
        }

        public new void Move(Player player)
        {
            bool isVisible = IsPlayerVisible(player.position);
            if (isVisible == true)
            {
                Attack(player);
            }
            else
            {
                Vector2[] freePositions = GetFreePositions(position);
                int randNum = random.Next(0, freePositions.Length);
                Vector2 nextPosition = freePositions[randNum];
                position = nextPosition;
            }
        }

        public new bool IsPlayerVisible(Vector2 playerPosition)
        {
            bool isVisible = true;
            if (playerPosition.X == position.X)
            {
                direction = Math.Sign(playerPosition.Y - position.Y);
                for (int i = position.Y + direction; i != playerPosition.Y; i += direction)
                {
                    if (mapObjects[position.X, i].isSolid == true)
                    {
                        isVisible = false;
                    }
                }
                attackDirection = 1;
            }
            else if (playerPosition.Y == position.Y)
            {
                direction = Math.Sign(playerPosition.X - position.X);
                for (int i = position.X + direction; i != playerPosition.X; i += direction)
                {
                    if (mapObjects[i, position.Y].isSolid == true)
                    {
                        isVisible = false;
                    }
                }
                attackDirection = 2;
            }
            else
            {
                isVisible = false;
            }
            return isVisible;
        }

        private void Attack(Player player)
        {
            AttackObject attackObject = new AttackObject(attackDirection, direction, position, true, player, mapObjects);
        }

        public new void TakeDamage()
        {
            if (hp <= 0) DrawMyself(" ", position);
            hp = hp - 30;
        }
    }

}

