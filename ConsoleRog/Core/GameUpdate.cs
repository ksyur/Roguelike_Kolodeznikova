using ConsoleRog.GameObjects.Entity;
using System;
using System.Collections.Generic;
using ConsoleRog.GameObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRog.Tools;

namespace ConsoleRog.Core
{
    public class GameUpdate
    {
        private bool gameRun = false;
        private Input input;
        private Player player;
        private GameObjectManager gameObjectManager;
        private View view;

        public GameUpdate(GameObjectManager gameObjectManager, View view)
        {
            this.gameObjectManager = gameObjectManager; 
            this.player = gameObjectManager.player;
            this.view = view;
            Start();
        }

        public void Start()
        {
            gameRun = true;
            input = new Input(player);
            Run();
        }

        public void Stop()
        {
            gameRun = false;
        }

        public void Run()
        {
            Update();
            while (gameRun == true)
            {
                input.ReadInput();
                if (player.hp <= 0 ) Stop();
            }
        }

        async Task Update()
        {
            while (gameRun == true)
            {
                var delay = Task.Delay(500); 
                var ret = UpdateP();
                await Task.WhenAll(delay, ret);
            }
        }

        async Task UpdateP()
        {
            view.RemoweEnemys(gameObjectManager.GetAllEnemys());
            gameObjectManager.Update();
            view.DrawEnemys(gameObjectManager.GetAllEnemys());
        }
    }
}
