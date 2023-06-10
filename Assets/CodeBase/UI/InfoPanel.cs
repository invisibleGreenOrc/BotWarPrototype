using CodeBase.Enemies.Spawners;
using UnityEngine;

namespace CodeBase.UI
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField]
        private BotSpawner[] _spawners;

        [SerializeField]
        private SpawnerView _spawnerView;

        private BotSpawner _lastSpawner;

        private void Start()
        {
            _spawnerView.Hide();
            
            for (int i = 0; i < _spawners.Length; i++)
            {
                _spawners[i].Selected += OnSpawnerSelected;
            }
        }

        private void OnSpawnerSelected(BotSpawner spawner)
        {
            if (_lastSpawner is not null)
            {
                _spawnerView.StatsChanged -= _lastSpawner.SetBotData;
            }
            
            _lastSpawner = spawner;
            
            _spawnerView.StatsChanged += _lastSpawner.SetBotData;
            
            _spawnerView.Show(_lastSpawner.GetBotData());
        }
    }
}