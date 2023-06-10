using System;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField]
        public float CurrentHP { get; private set; }

        private float _maxHP;

        public event Action HealthChanged;

        public void Init(float maxHeathPoints)
        {
            _maxHP = maxHeathPoints;
            CurrentHP = _maxHP;
        }

        public void TakeDamage(float damage)
        {
            CurrentHP -= damage;

            HealthChanged?.Invoke();
        }
    }
}