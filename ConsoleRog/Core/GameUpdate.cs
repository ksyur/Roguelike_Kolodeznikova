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
        private readonly List<Enemy> enemyObjects;
        private View gameView;

        public GameUpdate(Player player, List<Enemy> enemyObjects, View gameView)
        {
            this.player = player;
            this.enemyObjects = enemyObjects;
            this.gameView = gameView;
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
            }
        }

        async Task Update()
        {
            while (gameRun == true)
            {
                var delay = Task.Delay(800); 
                var ret = UpdateP();
                await Task.WhenAll(delay, ret);
            }
        }
        async Task UpdateP()
        {
            foreach (Enemy _enemyObjects in enemyObjects)
            {
                _enemyObjects.Update(player.position);
            }
            //gameView.UpdateMapData(gameObjects);
        }
    }
}
