using ConsoleRog.GameObjects.StaticObjects;
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
        public Shooter(string symbol, Vector2 position, int hp, MapObject[,] mapObjects, int mapHeight, int mapWidth, bool isSolid = true)
           : base(symbol, position, hp, mapObjects, mapHeight, mapWidth, isSolid)
        {
            DrawMyself(symbol, position);
        }
        
    }
}
