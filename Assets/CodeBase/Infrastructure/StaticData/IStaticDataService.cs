using CodeBase.Enemies;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        BotData GetBotData(BotType botType);

        Dictionary<BotType, BotData> GetBotData();

        void LoadBotData();
    }
}