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
        private int hp;
        
        public int Hp
        {
            get => hp;
            protected set
            {
                hp = value;
                if (hp <= 0)
                {
                    Console.WriteLine("Вы сдохли");
                }
            }
        }
        public Entity(string symbol, Vector2 position, int hp, bool isSolid = true) : base(symbol, position, isSolid)
        {

            this.hp = hp;
        }

        public override void DrawMyself(string _symbol, Vector2 _position)
        {
            base.DrawMyself(_symbol, position);
        }

    }
}
