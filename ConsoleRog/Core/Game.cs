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
        private Player player;
        private int mapWidth, mapHeight;
        public Game()
        {
            mapWidth = 35;
            mapHeight = 21;
            //gameMap = new Map(mapWidth, mapHeight);
            //gameView = new View(gameMap.GetMapData(), mapWidth, mapHeight);
            //player = new Player("P", new Vector2(1, 1), gameMap.GetMapData());
            //gameObjectManager = new GameObjectManager(gameMap.mazeData, mapWidth, mapHeight, gameView);
            //gameUpdate = new GameUpdate(player, gameObjectManager.gameObjects, gameView);
        }
        public void InitGame()
        {
            RestartLevel();
        }

        private void RestartLevel()
        {
            gameMap = new Map(mapWidth, mapHeight);
            player = new Player("P", new Vector2(1, 1), gameMap.GetMapData(), gameMap.finish);
            gameView = new View(gameMap.GetMapData(), mapWidth, mapHeight, player);
            gameObjectManager = new GameObjectManager(gameMap.mazeData, mapWidth, mapHeight, gameView, gameMap.finish);
            gameUpdate = new GameUpdate(player, gameObjectManager.enemyObjects, gameView);
        }
    }
}
