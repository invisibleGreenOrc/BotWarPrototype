using CodeBase.Infrastructure;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemies.Spawners
{
    public class BotSpawner : MonoBehaviour
    {
        private IBotFactory _botFactory;

        private BotType _botType;

        private void Awake()
        {
            _botFactory = Game.Instance.BotFactory;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _botFactory.CreateBot(_botType, transform);
            yield return new WaitForSeconds(2);
            _botFactory.CreateBot(_botType, transform);
        }
    }
}
