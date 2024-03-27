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
        private InfoPanel infoPanel;

        public GameUpdate(GameObjectManager gameObjectManager, View view, InfoPanel infoPanel)
        {
            this.gameObjectManager = gameObjectManager; 
            this.player = gameObjectManager.player;
            this.view = view;
            this.infoPanel = infoPanel;
            Start();
        }

        public void Start()
        {
            gameRun = true;
            input = new Input(player);
            Run();
        }

        public void Stop(int typeOfEnd)
        {
            switch (typeOfEnd)
            {
                case 1:
                    Console.WriteLine("\nВы проиграли...\n");
                    gameRun = false;
                    break;
                case 2:
                    Console.WriteLine("\nПоздравляем! Вы прошли игру!\n");
                    gameRun = false;
                    break;
                default:
                    return;
            }
        }

        public void Run()
        {
            Update();
            while (gameRun == true)
            {
                input.ReadInput();
                if (player.hp <= 0)
                {
                    infoPanel.Update();
                    Stop(1);
                }
                else if (player.finished)
                {
                    Stop(2);
                }
            }
        }

        async Task Update()
        {
            while (gameRun == true)
            {
                var delay = Task.Delay(1000); 
                var ret = UpdateP();
                await Task.WhenAll(delay, ret);
            }
        }

        async Task UpdateP()
        {
            view.RemoweEnemys(gameObjectManager.GetAllEnemys());
            gameObjectManager.Update();
            view.DrawEnemys(gameObjectManager.GetAllEnemys());
            infoPanel.Update();
        }
    }
}
