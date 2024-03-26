using ConsoleRog.GameObjects.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects.Entity
{
    public class Entity: GameObject
    {
        public int hp { get; set; }
        public MapObject[,] mapObjects;

        public Entity(string symbol, Vector2 position, MapObject[,] mapObjects, int hp, bool isSolid = true) : base(symbol, position, isSolid)
        {
            this.mapObjects = mapObjects;
            this.hp = hp;
        }

        public override void DrawMyself(string _symbol, Vector2 _position)
        {
            base.DrawMyself(_symbol, position);
        }

    }
}
