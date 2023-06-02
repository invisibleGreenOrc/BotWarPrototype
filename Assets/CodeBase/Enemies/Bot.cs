using UnityEngine;

namespace CodeBase.Enemies
{
    public class Bot : MonoBehaviour
    {
        public BotType Type { get; set; }

        public float HealthPoints { get; set; }

        public float FastAttackDamage { get; set; }

        public float FastAttackChance { get; set; }

        public float SlowAttackDamage { get; set; }

        public float AttackRange { get; set; }

        public float MissChance { get; set; }

        public float CriticalAttackChance { get; set; }

        public float CriticalDamageMultiplier { get; set; }
    }
}
