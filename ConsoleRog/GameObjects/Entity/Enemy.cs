using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects.Entity
{
    public class Enemy : Entity
    {
        private Random random = Random.Shared;
        private readonly MapObject[,] mapObjects;
        private readonly int mapHeight, mapWidth;
        private int damage;
        public Enemy(string symbol, Vector2 position, int hp, MapObject[,] mapObjects, int mapHeight, int mapWidth, bool isSolid = true, int damage = 5)
            : base(symbol, position, hp, isSolid)
        {
            this.mapObjects = mapObjects;
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            this.damage = damage;
            DrawMyself(symbol, position);
        }

        public void Update(Player player)
        {
            Move(player);
        }

        private void Move(Player player)
        {
            bool isVisible = IsPlayerVisible(player.position);
            if (isVisible == true)
            {
                if (IsPlayerNext(player.position))
                {
                    Attack(player);
                }
                else
                {
                    MoveToPlayer(player.position);
                }
            }
            else
            {
                Vector2[] freePositions = GetFreePositions(position);
                int randNum = random.Next(0, freePositions.Length);
                Vector2 nextPosition = freePositions[randNum];
                position = nextPosition;
            }
        }

        private Vector2[] GetFreePositions(Vector2 _position)
        {
            List<Vector2> freePositions = new List<Vector2>();
            for (int i = 0; i < 4; i++)
            {
                Vector2 newPosition = new Vector2((_position + Vector2.Directions[i]).X, (_position + Vector2.Directions[i]).Y);
                if (newPosition.X < mapWidth - 1 && newPosition.X > 0 && newPosition.Y < mapHeight - 1 && newPosition.Y > 0)
                {
                    if (mapObjects[newPosition.X, newPosition.Y].isSolid == false)
                    {
                        freePositions.Add(newPosition);
                    }
                }
            }
            return freePositions.ToArray();
        }

        private void MoveToPlayer(Vector2 playerPosition)
        {
            int deltaX = Math.Sign(playerPosition.X - position.X);
            int deltaY = Math.Sign(playerPosition.Y - position.Y);
            Vector2 nextPosition = new Vector2(position.X + deltaX, position.Y + deltaY);
            position = nextPosition;
        }

        public bool IsPlayerNext(Vector2 playerPosition)
        {
            bool isNext = false;
            if (playerPosition.X == position.X)
            {
                int direction = Math.Sign(playerPosition.Y - position.Y);
                if (playerPosition.Y - direction == position.Y)
                {
                    isNext = true;
                }
            }
            else if (playerPosition.Y == position.Y)
            {
                int direction = Math.Sign(playerPosition.X - position.X);
                if (playerPosition.X - direction == position.X)
                {
                    isNext = true;
                }
            }
            else
            {
                isNext = false;
            }
            return isNext;
        }

        private bool IsPlayerVisible(Vector2 playerPosition)
        {
            bool isVisible = true;
            if (playerPosition.X == position.X)
            {
                int direction = Math.Sign(playerPosition.Y - position.Y);
                for (int i = position.Y + direction; i != playerPosition.Y; i += direction)
                {
                    if (mapObjects[position.X, i].isSolid == true)
                    {
                        isVisible = false;
                    }
                }
            }
            else if (playerPosition.Y == position.Y)
            {
                int direction = Math.Sign(playerPosition.X - position.X);
                for (int i = position.X + direction; i != playerPosition.X; i += direction)
                {
                    if (mapObjects[i, position.Y].isSolid == true)
                    {
                        isVisible = false;
                    }
                }
            }
            else
            {
                isVisible = false;
            }
            return isVisible;
        }

        private void Attack(Player player)
        {
            if (hp > 0) player.TakeDamage(damage);
        }

        public void TakeDamage()
        {
            if (hp <= 0) DrawMyself(" ", position);
            hp = hp - 25;
        }
    }
}
