using ConsoleRog.GameObjects;
using ConsoleRog.GameObjects.Entity;
using ConsoleRog.MapCore;
using ConsoleRog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRog.Core
{
    class Game
    {
        private Map gameMap;
        private GameObjectManager gameObjectManager;
        private View gameView;
        private GameUpdate gameUpdate;
        private int mapWidth, mapHeight;
        private List<Enemy> gameEntitys;
        public Game()
        {
            mapWidth = 35;
            mapHeight = 21;
        }

        public void InitGame()
        {
            RestartLevel();
        }

        private void RestartLevel()
        {
            gameMap = new Map(mapWidth, mapHeight);
            gameObjectManager = new GameObjectManager(mapWidth, mapHeight, gameMap.GetMapData(), gameMap.finish);
            gameView = new View(gameMap.GetMapData(), mapWidth, mapHeight, gameObjectManager.player);
            gameUpdate = new GameUpdate(gameObjectManager, gameView);
        }
    }
}
