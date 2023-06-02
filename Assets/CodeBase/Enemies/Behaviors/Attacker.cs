using System;
using UnityEngine;

namespace CodeBase.Enemies.Behaviors
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField]
        private TriggerObserver _triggerObserver;

        [SerializeField]
        private SphereCollider _attackRangeSphere;



        private void OnEnable()
        {
            _triggerObserver.ColliderEntered += OnColliderEntered;
            //_triggerObserver.ColliderExited += OnColliderExited;
        }

        private void OnDisable()
        {
            _triggerObserver.ColliderEntered -= OnColliderEntered;
            //_triggerObserver.ColliderExited -= OnColliderExited;
        }

        public void SetRange(float range)
        {
            _attackRangeSphere.radius = range;
        }

        private void OnColliderEntered(Collider collider)
        {
            Debug.Log("Attack");
        }
    }
}
