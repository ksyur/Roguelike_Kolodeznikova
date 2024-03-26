using ConsoleRog.GameObjects.Entity;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.Core
{
    public class InfoPanel
    {
        private Player player;
        private int mapHeight;

        public InfoPanel(Player player, int mapHeight)
        {
            this.player = player;
            this.mapHeight = mapHeight + 1;
            Update();
        }

        public void Update()
        {
            string Info = $"Health: {player.hp}";
            ClearPrint(Info);
            DrawPanel(Info);
        }

        public void DrawPanel(string info)
        {
            Console.SetCursorPosition(0, mapHeight);
            Console.WriteLine(info);
        }

        private void ClearPrint(string msg)
        {
            Console.SetCursorPosition(0, mapHeight);
            Console.WriteLine($"\r{msg}{new String(' ', Console.BufferWidth - msg.Length + 10)}");
        }
    }
}
