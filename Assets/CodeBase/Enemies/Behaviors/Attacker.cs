using UnityEngine;

namespace CodeBase.Enemies.Behaviors
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField]
        private SphereCollider _attackRangeSphere;

        private float _fastAttackDamage { get; set; }

        private float _fastAttackChance { get; set; }

        private float _slowAttackDamage { get; set; }

        private float _attackRange { get; set; }

        private float _missChance { get; set; }

        private float _criticalAttackChance { get; set; }

        private float _criticalDamageMultiplier { get; set; }

        private float _coolDown = 2f;

        private float _currentCoolDown = 0f;

        private Health _target;

        private void Update()
        {
            if (_currentCoolDown <= 0 && _target != null)
            {
                Attack();
            }
            else
            {
                _currentCoolDown -= Time.deltaTime;
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
            float randomValue = UnityEngine.Random.Range(0f, 1f);

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

            if (IsCriticalHit())
            {
                damage *= _criticalDamageMultiplier;
            }

            _target.TakeDamage(damage);
            Debug.Log(damage);
        }

        private float CalculateDamage()
        {
            if (IsAttemptSuccessful(_fastAttackChance))
            {
                return _fastAttackDamage;
            }

            return _slowAttackDamage;
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
