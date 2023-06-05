using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Enemies
{
    public interface IBotFactory
    {
        GameObject CreateBot(BotData botData, PlayerType playerType, Transform parent);
    }
}