using CodeBase.Enemies;
using CodeBase.Infrastructure.Input;
using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        private static Game _instance;

        public IInputService InputService { get; private set; }

        public IStaticDataService StaticDataService { get; private set; }

        public IBotFactory BotFactory { get; private set; }

        public static Game Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        public Game()
        {
            CreateInputService(); 
            CreateStaticDataService();
        }

        private void CreateInputService() => InputService = new InputService();

        private void CreateStaticDataService()
        {
            StaticDataService = new StaticDataService();
            StaticDataService.LoadData();
        }
    }
}