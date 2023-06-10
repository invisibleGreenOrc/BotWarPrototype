using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StaticData;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Enemies.Spawners
{
    public class BotSpawner : MonoBehaviour, IPointerClickHandler
    {
        private IBotFactory _botFactory;

        private BotData _currentBotData;

        [SerializeField]
        private BotType _startBotType;

        [SerializeField]
        private PlayerType _playerType;

        private Material _material;

        public event Action<BotSpawner> Selected;

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

        public BotData GetBotData()
        {
            return _currentBotData;
        }

        public void SetBotData(BotData newData)
        {
            newData.Prefab = _currentBotData.Prefab;
            _currentBotData = newData;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Selected?.Invoke(this);
        }

        private IEnumerator Spawn()
        {
            for (int i = 0; i < 10; i++)
            {
                _botFactory.CreateBot(_currentBotData, _playerType, transform);
                yield return new WaitForSeconds(1);
            }
        }
    }
}