using CodeBase.Enemies.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class BotAI : MonoBehaviour
    {
        [SerializeField]
        private Bot _bot;

        [SerializeField]
        private TriggerObserver _viewRangeObserver;

        [SerializeField]
        private TriggerObserver _attackRangeObserver;

        [SerializeField]
        private Follower _follower;

        [SerializeField]
        private Attacker _attacker;

        private HashSet<Bot> _visibleEnemies = new();

        private HashSet<Health> _enemiesInAttackZone = new();

        private Bot _currentTarget;

        private void OnEnable()
        {
            _viewRangeObserver.ColliderEntered += OnColliderEnteredVisibilityZone;
            _attackRangeObserver.ColliderEntered += OnColliderEnteredAttackZone;
        }

        private void OnDisable()
        {
            _viewRangeObserver.ColliderEntered -= OnColliderExitVisibilityZone;
            _attackRangeObserver.ColliderEntered -= OnColliderExitAttackZone;
        }

        private void OnColliderEnteredVisibilityZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _visibleEnemies.Add(bot);

                if (_currentTarget == null)
                {
                    _currentTarget = bot;

                    _follower.SetTarget(bot.transform);
                }
            }
        }

        private void OnColliderExitVisibilityZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _visibleEnemies.Remove(bot);
            }
        }

        private void OnColliderEnteredAttackZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                Health target = bot.GetComponent<Health>();

                _enemiesInAttackZone.Add(target);

                _attacker.SetTarget(target);
                _follower.enabled = false;
            }
        }

        private void OnColliderExitAttackZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _enemiesInAttackZone.Remove(bot.GetComponent<Health>());
            }
        }
    }
}