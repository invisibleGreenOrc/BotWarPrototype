using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StaticData;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace CodeBase.Enemies.Spawners
{
    public class BotSpawner : MonoBehaviour
    {
        private IBotFactory _botFactory;

        [SerializeField]
        private BotData _currentBotData;

        [SerializeField]
        private BotType _startBotType;

        [SerializeField]
        private PlayerType _playerType;

        private Material _material;

        private void Awake()
        {
            _botFactory = new BotFactory();
        }

        private void Start()
        {
            _currentBotData = Game.Instance.StaticDataService.GetBotData(_startBotType);
            _material = Game.Instance.StaticDataService.GetPlayerMaterial(_playerType);

            GetComponent<MeshRenderer>().material = _material;

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _botFactory.CreateBot(_currentBotData, _material, transform);
            yield return new WaitForSeconds(3);
            _botFactory.CreateBot(_currentBotData, _material, transform);
        }
    }
}
