using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Enemies.Behaviors
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField]
        private SphereCollider _attackRangeSphere;

        private float _fastAttackDamage;

        private float _fastAttackChance;

        private float _slowAttackDamage;

        private float _attackRange;

        private float _missChance;

        private float _criticalAttackChance;

        private float _criticalDamageMultiplier;

        private float _coolDown = 2f;

        private float _currentCoolDown = 0f;

        private Health _target;

        private void OnDisable()
        {
            _target = null;
        }

        private void Update()
        {
            if (_currentCoolDown > 0)
            {
                _currentCoolDown -= Time.deltaTime;
                return;
            }
            
            if (_target is not null)
            {
                Attack();
            }
        }

        public void Init(float fastAttackDamage, float fastAttackChance, float slowAttackDamage, float attackRange, float missChance, float criticalAttackChance, float criticalDamageMultiplier)
        {
            _fastAttackDamage = fastAttackDamage;
            _fastAttackChance = fastAttackChance;
            _slowAttackDamage = slowAttackDamage;
            _attackRange = attackRange;
            _missChance = missChance;
            _criticalAttackChance = criticalAttackChance;
            _criticalDamageMultiplier = criticalDamageMultiplier;

            SetRange(_attackRange);
        }

        public void SetTarget(Health target)
        {
            _target = target;
        }

        private void SetRange(float range)
        {
            _attackRangeSphere.radius = range;
        }

        private bool IsAttemptSuccessful(float chance)
        {
            float randomValue = Random.Range(0f, 1f);

            return randomValue <= chance;
        }

        private void Attack()
        {
            _currentCoolDown = _coolDown;

            if (IsMiss())
            {
                return;
            }

            float damage = CalculateDamage();
            
            _target.TakeDamage(damage);
        }

        private float CalculateDamage()
        {
            float damage = _slowAttackDamage;
            
            if (IsAttemptSuccessful(_fastAttackChance))
            {
                damage = _fastAttackDamage;
            }
            
            if (IsCriticalHit())
            {
                damage *= _criticalDamageMultiplier;
            }

            return damage;
        }

        private bool IsMiss()
        {
            return IsAttemptSuccessful(_missChance);
        }

        private bool IsCriticalHit()
        {
            return IsAttemptSuccessful(_criticalAttackChance);
        }
    }
}
