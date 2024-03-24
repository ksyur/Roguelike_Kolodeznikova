using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.GameObjects
{
    public class GameObject
    {
        public string symbol { get; set; }
        public Vector2 position { get; set; }

        public bool isSolid;
        
        
        public GameObject(string _symbol, Vector2 _position, bool _isSolid)
        {
            symbol = _symbol;
            position = _position;
            isSolid = _isSolid;
        }

        public virtual void DrawMyself(string _symbol, Vector2 _position)
        {
            ConsoleHelper.WriteToBufferAt(_symbol, _position.X, _position.Y);
        }

        public virtual void Update()
        {
        }
    }
}
