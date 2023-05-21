using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Input;
using UnityEngine;

namespace CodeBase.Camera
{
    public class Mover : MonoBehaviour
    {
        private IInputService _inputService;

        private Vector3 _moveInputDirection;

        [SerializeField]
        private float _speed = 5f;

        private void Update()
        {
            Move();
        }

        private void OnEnable()
        {
            if (_inputService == null)
            {
                _inputService = Game.Instance.InputService;
            }

            _inputService.MoveInputChanged += OnMove;
        }

        private void OnDisable()
        {
            _inputService.MoveInputChanged -= OnMove;
        }

        private void OnMove(Vector2 input)
        {
            _moveInputDirection = new Vector3(input.x, 0, input.y);
        }

        private void Move()
        {
            var lookDirectionXZ = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
            var rightDirectionXZ = new Vector3(lookDirectionXZ.z, 0, -lookDirectionXZ.x);
            var moveDirection = lookDirectionXZ * _moveInputDirection.z + rightDirectionXZ * _moveInputDirection.x;

            transform.Translate(_speed * Time.deltaTime * moveDirection, Space.World);
        }
    }
}
