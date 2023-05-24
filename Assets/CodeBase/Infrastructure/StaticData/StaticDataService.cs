using CodeBase.Enemies;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<BotType, BotData> _botsData;

        public void LoadBotData()
        {
            _botsData = Resources.LoadAll<BotStaticData>("StaticData/Bots").ToDictionary(x => x.Data.BotType, x => x.Data);
        }

        public BotData GetBotData(BotType botType)
        {
            if (_botsData.TryGetValue(botType, out BotData botData))
            {
                return botData;
            }

            return new BotData();
        }

        public Dictionary<BotType, BotData> GetBotData()
        {
            return new Dictionary<BotType, BotData>(_botsData);
        }
    }
}