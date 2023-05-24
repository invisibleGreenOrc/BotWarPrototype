using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "BotData", menuName = "Static Data/Bot Data")]
    public class BotStaticData : ScriptableObject
    {
        public BotData Data;
    }
}