using UnityEngine;

namespace CodeBase.Enemies
{
    public class Mover : MonoBehaviour
    {
        [SerializeField]
        private int _movementSpeed = 5;

        public void Move(Vector3 target)
        {
            Vector3 deltaPosition = _movementSpeed * Time.deltaTime * GetMoveDirection(target);

            transform.position += new Vector3(deltaPosition.x, 0, deltaPosition.z);
        }

        private Vector3 GetMoveDirection(Vector3 target)
        {
            Vector3 moveDirection = (target - transform.position).normalized;

            return moveDirection;
        }
    }
}