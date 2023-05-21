using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameLauncher : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
        }
    }
}