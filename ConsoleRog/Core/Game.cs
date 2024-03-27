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
    public class Game
    {
        private int mapWidth, mapHeight;
        public Game()
        {
            mapWidth = 65;
            mapHeight = 25;
            InitGame();
        }

        public void InitGame()
        {
            Map gameMap = new Map(mapWidth, mapHeight);
            GameObjectManager gameObjectManager = new GameObjectManager(mapWidth, mapHeight, gameMap.mapObjects, gameMap.finish);
            View gameView = new View(gameMap.mapObjects, mapWidth, mapHeight, gameObjectManager.player);
            InfoPanel infoPanel = new InfoPanel(gameObjectManager.player, mapHeight);
            GameUpdate gameUpdate = new GameUpdate(gameObjectManager, gameView, infoPanel);
        }

    }
}
