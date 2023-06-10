using System;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class Bot : MonoBehaviour
    {
        public bool IsDead { get; private set; } = false;
        
        [SerializeField]
        private Health _health;
        
        public PlayerType PlayerType { get; private set; }

        public event Action<Bot> Died;

        public void Init(PlayerType playerType)
        {
            PlayerType = playerType;
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_health.CurrentHP <= 0 && IsDead == false)
            {
                Die();
            }
        }

        private void Die()
        {
            IsDead = true;
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}