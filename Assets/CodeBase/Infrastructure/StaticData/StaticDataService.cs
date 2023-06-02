using CodeBase.Enemies;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<BotType, BotData> _botsData = new();

        private Dictionary<PlayerType, Material> _playerMaterials = new();

        public void LoadData()
        {
            LoadBotData();
            LoadPlayerMaterials();
        }

        public BotData GetBotData(BotType botType)
        {
            if (_botsData.TryGetValue(botType, out BotData botData))
            {
                return botData;
            }

            return new BotData();
        }

        public Dictionary<BotType, BotData> GetBotsData()
        {
            return new Dictionary<BotType, BotData>(_botsData);
        }

        public Material GetPlayerMaterial(PlayerType playerType)
        {
            return _playerMaterials[playerType];
        }

        private void LoadBotData()
        {
            _botsData = Resources.LoadAll<BotStaticData>("StaticData/Bots").ToDictionary(x => x.Data.BotType, x => x.Data);
        }

        private void LoadPlayerMaterials()
        {
            PlayerTypeMaterial[] playerTypeMaterials = Resources.Load<PlayerTypeStaticData>("StaticData/PlayerTypes/PlayerTypeData").PlayerTypeMaterials;

            for (int i = 0; i < playerTypeMaterials.Length; i++)
            {
                _playerMaterials.Add(playerTypeMaterials[i].PlayerType, playerTypeMaterials[i].Material);
            }
        }
    }
}