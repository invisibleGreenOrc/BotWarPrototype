using CodeBase.Enemies;
using System;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [Serializable]
    public struct BotData
    {
        public BotType BotType;

        public float HealthPoints;

        public float MovementSpeed;

        public float FastAttackDamage;

        public float FastAttackChance;

        public float SlowAttackDamage;

        public float AttackRange;

        public float MissChance;

        public float CriticalAttackChance;

        public float CriticalDamageMultiplier;

        public GameObject Prefab;
    }
}
