using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.Tools
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        //для передвижения
        public static Vector2 Up => new Vector2(0, -1);
        public static Vector2 Down => new Vector2(0, 1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Right => new Vector2(1, 0);

        public static Vector2[] Directions = new Vector2[4] { Up, Down, Left, Right };

        //для генерации лабиринта (через клетку)
        public static Vector2 Up2 => new Vector2(0, -2);
        public static Vector2 Down2 => new Vector2(0, 2);
        public static Vector2 Left2 => new Vector2(-2, 0);
        public static Vector2 Right2 => new Vector2(2, 0);

        public static Vector2[] Directions2 = new Vector2[4] { Up2, Down2, Left2, Right2 };
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

    }
}
