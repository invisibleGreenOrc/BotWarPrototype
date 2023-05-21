using CodeBase.Infrastructure.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        private static Game _instance;

        public IInputService InputService { get; private set; }

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
            InputService = new InputService();
        }
    }
}