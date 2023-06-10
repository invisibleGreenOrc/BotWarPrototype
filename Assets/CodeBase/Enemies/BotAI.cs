using CodeBase.Enemies.Behaviors;
using System.Collections.Generic;
using System.Linq;
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

        private HashSet<Bot> _enemiesInAttackZone = new();

        private Bot _currentTarget;

        private void OnEnable()
        {
            _viewRangeObserver.ColliderEntered += OnColliderEnteredVisibilityZone;
            _attackRangeObserver.ColliderEntered += OnColliderEnteredAttackZone;
            _bot.Died += OnDied;
        }

        private void OnDisable()
        {
            _viewRangeObserver.ColliderEntered -= OnColliderExitVisibilityZone;
            _attackRangeObserver.ColliderEntered -= OnColliderExitAttackZone;
            _bot.Died -= OnDied;
        }

        private void OnDied(Bot obj)
        {
            _follower.enabled = false;
            _attacker.enabled = false;
            _currentTarget = null;
            enabled = false;
        }

        private void OnEnemyDied(Bot enemy)
        {
            _visibleEnemies.Remove(enemy);
            _enemiesInAttackZone.Remove(enemy);
            
            if (_currentTarget == enemy)
            {
                _currentTarget = null;
                FindNewTarget();
            }
        }
        
        private void FindNewTarget()
        {
            if (_enemiesInAttackZone.FirstOrDefault() is { } targetToAttack)
            {
                _currentTarget = targetToAttack;
                StartAttacking(targetToAttack);
                return;
            }

            if (_visibleEnemies.FirstOrDefault() is { } targetToFollow)
            {
                _currentTarget = targetToFollow;
            }
            
            StartFollowing();
        }

        private void StartFollowing()
        {
            _attacker.enabled = false;

            if (_currentTarget is null)
            {
                _follower.RemoveTarget();
            }
            else
            {
                _follower.SetTarget(_currentTarget.transform);
            }
            
            _follower.enabled = true;
        }

        private void StartAttacking(Bot target)
        {
            _follower.enabled = false;
            _attacker.enabled = true;
            _attacker.SetTarget(target.GetComponent<Health>());
        }

        private void OnColliderEnteredVisibilityZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _visibleEnemies.Add(bot);
                bot.Died += OnEnemyDied;

                if (_currentTarget == null)
                {
                    _currentTarget = bot;

                    StartFollowing();
                }
            }
        }

        private void OnColliderExitVisibilityZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _visibleEnemies.Remove(bot);
                bot.Died -= OnEnemyDied;

                if (_currentTarget == bot)
                {
                    _currentTarget = null;
                    FindNewTarget();
                }
            }
        }

        private void OnColliderEnteredAttackZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _enemiesInAttackZone.Add(bot);
                bot.Died += OnEnemyDied;
                
                FindNewTarget();
            }
        }

        private void OnColliderExitAttackZone(Collider collider)
        {
            if (collider.TryGetComponent(out Bot bot) && bot.PlayerType != _bot.PlayerType)
            {
                _enemiesInAttackZone.Remove(bot);
                bot.Died -= OnEnemyDied;
                
                if (_currentTarget == bot)
                {
                    _currentTarget = null;
                    FindNewTarget();
                }
            }
        }
    }
}