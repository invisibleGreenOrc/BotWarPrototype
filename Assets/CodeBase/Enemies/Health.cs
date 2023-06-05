using UnityEngine;

namespace CodeBase.Enemies
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _healthPoints;

        private float _maxHealthPoints;

        public void Init(float maxHeathPoints)
        {
            _maxHealthPoints = maxHeathPoints;
            _healthPoints = _maxHealthPoints;
        }

        public void TakeDamage(float damage)
        {
            _healthPoints -= damage;

            if (_healthPoints <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}