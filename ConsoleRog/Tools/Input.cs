using ConsoleRog.GameObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.Tools
{
    internal class Input
    {
        Player player;
        public Input(Player player)
        {
            this.player = player;
        }

        public void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        //Console.WriteLine("up");
                        player.Move(1);
                        break;
                    case ConsoleKey.DownArrow:
                        //Console.WriteLine("down");
                        player.Move(2);
                        break;
                    case ConsoleKey.LeftArrow:
                        //Console.WriteLine("left");
                        player.Move(3);
                        break;
                    case ConsoleKey.RightArrow:
                        //Console.WriteLine("right");
                        player.Move(4);
                        break;
                }
            }
        }
    }
}
