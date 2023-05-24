using System;
using UnityEngine;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> ColliderEntered;

        public event Action<Collider> ColliderExited;

        private void OnTriggerEnter(Collider other)
        {
            ColliderEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            ColliderExited?.Invoke(other);
        }
    }
}
