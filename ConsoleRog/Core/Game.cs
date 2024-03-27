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
        private Map gameMap;
        private GameObjectManager gameObjectManager;
        private View gameView;
        private InfoPanel infoPanel;
        private GameUpdate gameUpdate;

        private int mapWidth, mapHeight;
        public Game()
        {
            mapWidth = 65;
            mapHeight = 25;
            InitGame();
        }

        public void InitGame()
        {
            gameMap = new Map(mapWidth, mapHeight);
            gameObjectManager = new GameObjectManager(mapWidth, mapHeight, gameMap.mapObjects, gameMap.finish);
            gameView = new View(gameMap.mapObjects, mapWidth, mapHeight, gameObjectManager.player);
            infoPanel = new InfoPanel(gameObjectManager.player, mapHeight);
            gameUpdate = new GameUpdate(gameObjectManager, gameView, this, infoPanel);
        }

    }
}
