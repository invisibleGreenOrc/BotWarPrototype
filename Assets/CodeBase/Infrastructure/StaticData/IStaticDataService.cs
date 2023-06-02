using CodeBase.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        BotData GetBotData(BotType botType);

        Dictionary<BotType, BotData> GetBotsData();

        void LoadData();

        Material GetPlayerMaterial(PlayerType playerType);
    }
}