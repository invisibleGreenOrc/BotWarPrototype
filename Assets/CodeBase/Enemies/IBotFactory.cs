using UnityEngine;

namespace CodeBase.Enemies
{
    public interface IBotFactory
    {
        GameObject CreateBot(BotType botType, Transform parent);
    }
}