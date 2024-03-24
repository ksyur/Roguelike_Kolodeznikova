using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects.StaticObjects
{
    public class MapObject: GameObject
    {
        public bool isVisited;
        public MapObject(string symbol, Vector2 position, bool isSolid, bool isVisited) : base(symbol, position, isSolid)
        {
           this.isVisited = isVisited;
        }
    }
}
