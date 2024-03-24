using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.GameObjects.Entity
{
    internal class Shooter: Enemy
    {
        private Random random = Random.Shared;
        public Shooter(string symbol, Vector2 position, int hp, GameObject[,] mapObjects, int mapHeight, int mapWidth, Vector2 finish, bool isSolid = true)
           : base(symbol, position, hp, mapObjects, mapHeight, mapWidth, finish, isSolid)
        {
            DrawMyself(symbol, position);
        }
        
    }
}
