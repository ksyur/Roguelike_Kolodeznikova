using ConsoleRog.GameObjects.Entity;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.GameObjects
{
    public class AttackObject
    {
        private readonly int attackType;
        private readonly int direction;
        private Vector2 position;
        private bool isSolid;
        private Player player;
        private readonly MapObject[,] mapObjects;
        private string symbol;

        public AttackObject(int attackType, int direction, Vector2 position, bool isSolid, Player player, MapObject[,] mapObjects)
        {
            this.attackType = attackType;
            this.direction = direction;
            this.position = position;
            this.isSolid = isSolid;
            this.player = player;
            this.mapObjects = mapObjects;
            switch (attackType)
            {
                case 1: //движется по y
                    symbol = "|";
                    break;
                case 2: //движется по x
                    symbol = "-";
                    break;
                default:
                    return;
            }
            Update();
        }

        async Task Update()
        {
            while (isSolid == true)
            {
                var delay = Task.Delay(500);
                var ret = Move();
                await Task.WhenAll(delay, ret);
            }
        }

        async Task Move()
        {
            switch (attackType)
            {
                case 1: //движется по y
                    Vector2 nextPosition = new Vector2(position.X, position.Y + direction);
                    if (NextPosition(nextPosition))
                    {
                        DrawMyself(" ", position);
                        position = nextPosition;
                        DrawMyself(symbol, position);
                    }
                    break;
                case 2: //движется по x
                    Vector2 nextPosition2 = new Vector2(position.X + direction, position.Y);
                    if (NextPosition(nextPosition2))
                    {
                        DrawMyself(" ", position);
                        position = nextPosition2;
                        DrawMyself(symbol, position);
                    }
                    break;
                default:
                    return;
            }
        }

        private bool NextPosition(Vector2 _position)
        {
            if (mapObjects[_position.X, _position.Y].isSolid == true)
            {
                isSolid = false;
                DrawMyself(" ", position);
                return false;
            }
            else if (_position.Y == player.position.Y && _position.X == player.position.X)
            {
                isSolid = false;
                player.TakeDamage(5);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DrawMyself(string _symbol, Vector2 _position)
        {
            ConsoleHelper.WriteToBufferAt(_symbol, _position.X, _position.Y);
        }
    }
}
