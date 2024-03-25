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
        private Player player;
        private int mapWidth, mapHeight;
        private List<Entity> gameEntitys;
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
            player = new Player("P", new Vector2(1, 1), gameMap.GetMapData(), gameMap.finish);
            gameObjectManager = new GameObjectManager(mapWidth, mapHeight, gameMap.GetMapData());
            gameEntitys = gameObjectManager.GetAllEnemys();
            gameEntitys.Add(player);
            gameView = new View(gameMap.GetMapData(), mapWidth, mapHeight, player);
            gameUpdate = new GameUpdate(player, gameObjectManager.enemyObjects, gameView);
        }
    }
}
