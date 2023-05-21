using CodeBase.Enemies;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "BotData", menuName = "Static Data/Bot Data")]
    public class BotStaticData : ScriptableObject
    {
        public BotType BotType;

        public int HealthPoints;

        public int MovementSpeed;

        public int FastAttackDamage;

        public float FastAttackChance;

        public int SlowAttackDamage;

        public float MissChance;

        public float CriticalAttackChance;

        public float CriticalDamageMultiplier;

        public GameObject Prefab;
    }
}