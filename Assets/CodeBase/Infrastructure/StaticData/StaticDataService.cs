using CodeBase.Enemies;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<BotType, BotStaticData> _botsData;

        public void LoadBotData()
        {
            _botsData = Resources.LoadAll<BotStaticData>("StaticData/Bots").ToDictionary(x => x.BotType, x => x);
        }

        public BotStaticData GetBotData(BotType botType)
        {
            if (_botsData.TryGetValue(botType, out BotStaticData botData))
            {
                return botData;
            }

            return null;
        }
    }
}