﻿using ConsoleRog.GameObjects;
using ConsoleRog.GameObjects.Entity;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.MapCore;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.Core
{
    public class View
    {
        public GameObject[,] mapData { get; private set; }
        private int mapWidth;
        private int mapHeight;
        private Player player;

        public View(GameObject[,] mapData, int mapWidth, int mapHeight, Player player)
        {
            this.mapData = mapData;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.player = player;
            DrawMap();
            //DrawInfoPanel();
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Console.Write(mapData[x, y].symbol);
                }
                Console.Write("\n");
            }
        }
        private void DrawInfoPanel()
        {
            var infoBuilder = new StringBuilder(30);
            if (player.Hp > 0)
            {
                infoBuilder.Append($"Health: {player.Hp}  Punch: Press 'E'");
            }
            string info = infoBuilder.ToString();
            
        }
    }
}
