using UnityEngine;

namespace CodeBase.Enemies.Behaviors
{
    [RequireComponent(typeof(Mover))]
    public class Follower : MonoBehaviour
    {
        private Mover _mover;

        [SerializeField]
        private TriggerObserver _triggerObserver;

        [SerializeField]
        private Vector3 _defaultTarget = new(0, 0, 0);

        private Transform _target;

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

        private void Start()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (_target == null)
            {
                _mover.Move(_defaultTarget);
            }
            else
            {
                _mover.Move(_target.position);
            }
        }

        private void OnColliderEntered(Collider collider)
        {
            if (_target == null)
            {
                _target = collider.transform;
            }
        }
    }
}
