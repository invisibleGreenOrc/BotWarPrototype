using UnityEngine;

namespace CodeBase.Enemies.Behaviors
{
    public class Mover : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed = 5f;

        public void Move(Vector3 target)
        {
            Vector3 deltaPosition = _movementSpeed * Time.deltaTime * GetMoveDirection(target);

            transform.position += new Vector3(deltaPosition.x, 0, deltaPosition.z);
        }

        public void SetSpeed(float speed)
        {
            _movementSpeed = speed;
        }

        private Vector3 GetMoveDirection(Vector3 target)
        {
            Vector3 moveDirection = (target - transform.position).normalized;

            return moveDirection;
        }
    }
}