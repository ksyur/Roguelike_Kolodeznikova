using ConsoleRog.GameObjects;
using ConsoleRog.GameObjects.StaticObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vector2 = ConsoleRog.Tools.Vector2;

namespace ConsoleRog.MapCore
{
    public class Map
    {
        private int mapHeight, mapWidth;
        public MapObject[,] mapObjects { get; private set; }
        public Vector2 finish { get; private set; }

        public Map(int _width, int _height)
        {
            mapHeight = _height;
            mapWidth = _width;
            mapObjects = new MapObject[_width, _height];
            Initialize();
        }

        private void Initialize()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (y % 2 != 0 && x % 2 != 0 && y < mapHeight - 1 && x < mapWidth - 1) //если клетка нечетная и в пределах лабиринта
                    {
                        mapObjects[x, y] = new MapObject(" ", new Vector2(x, y), false, false);
                    }
                    else
                    {
                        mapObjects[x, y] = new MapObject("█", new Vector2(x, y), true, false);
                    }
                }
            }
            MazeGenerator mazeGenerator = new MazeGenerator(mapWidth, mapHeight, mapObjects);
            mapObjects = mazeGenerator.Generate();
            mapObjects[mapWidth - 2, mapHeight - 2] = new MapObject("#", new Vector2(mapWidth - 2, mapHeight - 2), false, false);
            finish = new Vector2(mapWidth - 2, mapHeight - 2);
        }

        public MapObject[,] GetMapData()
        {
            return mapObjects;
        }
    }
}
