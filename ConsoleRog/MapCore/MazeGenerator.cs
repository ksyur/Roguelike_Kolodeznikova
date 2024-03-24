using ConsoleRog.GameObjects;
using ConsoleRog.GameObjects.StaticObjects;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.MapCore
{
    public class MazeGenerator
    {
        private Random random = Random.Shared;
        private readonly MapObject[,] mazeData;
        private readonly int mapHeight, mapWidth;

        public MazeGenerator(int mapWidth, int mapHeight, MapObject[,] mazeData)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.mazeData = mazeData;
        }

        public MapObject[,] Generate()
        {
            int freePositionsCount = Convert.ToInt32(mapHeight / 2) * Convert.ToInt32(mapWidth / 2);
            Vector2 startPosition = new Vector2(1, 1);

            while (freePositionsCount > 0)
            {
                Vector2[] neighbours = GetNeighbours(startPosition);
                if (neighbours.Length > 0)
                {
                    int randNum = random.Next(0, neighbours.Length);
                    Vector2 nextPosition = neighbours[randNum];
                    RemoveWall(startPosition, nextPosition);
                    mazeData[nextPosition.X, nextPosition.Y] = new MapObject(" ", new Vector2(nextPosition.X, nextPosition.Y), false, true);
                    startPosition = nextPosition;
                    freePositionsCount -= 1;
                }
                else if (neighbours.Length == 0)
                {
                    for (int x = 0; x < mapWidth; x++)
                    {
                        for (int y = 0; y < mapHeight; y++)
                        {
                            if (mazeData[x, y].isSolid == false && mazeData[x, y].isVisited == true)
                            {
                                neighbours = GetNeighbours(new Vector2(x, y));
                                if (neighbours.Length > 0)
                                {
                                    startPosition = new Vector2(x, y);
                                }
                            }

                        }
                    }
                }
            }
            return mazeData;
        }

        private Vector2[] GetNeighbours(Vector2 _position)
        {
            List<Vector2> _neighbours = new List<Vector2>();
            for (int i = 0; i < 4; i++)
            {
                if ((_position + Vector2.Directions2[i]).X < mapWidth - 1 && (_position + Vector2.Directions2[i]).X > 0 &&
                    (_position + Vector2.Directions2[i]).Y < mapHeight - 1 && (_position + Vector2.Directions2[i]).Y > 0)
                {
                    if (mazeData[(_position + Vector2.Directions2[i]).X, (_position + Vector2.Directions2[i]).Y].isVisited == false &&
                        mazeData[(_position + Vector2.Directions2[i]).X, (_position + Vector2.Directions2[i]).Y].isSolid == false)
                    {
                        _neighbours.Add(new Vector2((_position + Vector2.Directions2[i]).X, (_position + Vector2.Directions2[i]).Y));
                    }
                }
            }
            return _neighbours.ToArray();
        }

        private void RemoveWall(Vector2 _startPosition, Vector2 _nextPosition)
        {
            int xDiff = _startPosition.X - _nextPosition.X;
            int yDiff = _startPosition.Y - _nextPosition.Y;
            if (xDiff < 0) mazeData[_nextPosition.X + xDiff + 1, _startPosition.Y] = new MapObject(" ", new Vector2(_nextPosition.X + xDiff + 1, _startPosition.Y), false, true);
            if (xDiff > 0) mazeData[_nextPosition.X + xDiff - 1, _startPosition.Y] = new MapObject(" ", new Vector2(_nextPosition.X + xDiff - 1, _startPosition.Y), false, true);
            if (yDiff > 0) mazeData[_startPosition.X, _nextPosition.Y + yDiff - 1] = new MapObject(" ", new Vector2(_startPosition.X, _nextPosition.Y + yDiff - 1), false, true);
            if (yDiff < 0) mazeData[_startPosition.X, _nextPosition.Y + yDiff + 1] = new MapObject(" ", new Vector2(_startPosition.X, _nextPosition.Y + yDiff + 1), false, true);
        }
    }
}
