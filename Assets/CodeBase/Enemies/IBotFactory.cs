using UnityEngine;

namespace CodeBase.Enemies
{
    public interface IBotFactory
    {
        GameObject CreateBot(BotType botType, Material material, Transform parent);
    }
}