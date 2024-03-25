﻿using ConsoleRog.GameObjects.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects.Entity
{
    public class Player: Entity
    {
        private readonly MapObject[,] mapObjects;
        private readonly Vector2 finish;
        public Player(string symbol, Vector2 position, MapObject[,] mapObjects, Vector2 finish, int hp = 100, bool isSolid = true) : base(symbol, position, hp, isSolid)
        {
            this.mapObjects = mapObjects;
            this.finish= finish;
            DrawMyself(symbol, position);
        }

        public void Update(Vector2 _newPosition)
        {
            DrawMyself(mapObjects[position.X, position.Y].symbol, position);
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
                default:
                    return;
            }

            if (mapObjects[newPosition.X, newPosition.Y].isSolid == false)
            {
                Update(newPosition);
                if (newPosition.X == finish.X && newPosition.Y == finish.Y)
                {
                    Console.WriteLine("end");
                }
            }
            
        }
    }
}
