using UnityEngine;

namespace CodeBase.Enemies.Behaviors
{
    [RequireComponent(typeof(Mover))]
    public class Follower : MonoBehaviour
    {
        private Mover _mover;

        [SerializeField]
        private Vector3 _defaultTarget = new(0, 0, 0);

        private Transform _target;

        private void Start()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (_target is null)
            {
                _mover.Move(_defaultTarget);
            }
            else
            {
                _mover.Move(_target.position);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void RemoveTarget()
        {
            _target = null;
        }
    }
}
