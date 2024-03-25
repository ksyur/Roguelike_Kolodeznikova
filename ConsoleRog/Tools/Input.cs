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
                        player.Move(1);
                        break;
                    case ConsoleKey.DownArrow:
                        player.Move(2);
                        break;
                    case ConsoleKey.LeftArrow:
                        player.Move(3);
                        break;
                    case ConsoleKey.RightArrow:
                        player.Move(4);
                        break;
                    case ConsoleKey.F:  //Щит для атаки и защиты
                        player.Move(5);
                        break;
                }
            }
        }
    }
}
