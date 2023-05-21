using System;
using UnityEngine;
using static CodeBase.Infrastructure.Input.GameInput;
using static UnityEngine.InputSystem.InputAction;

namespace CodeBase.Infrastructure.Input
{
    public class InputService : IInputService, IGameplayActions
    {
        private readonly GameInput _gameInput;

        public event Action<Vector2> MoveInputChanged;

        public InputService()
        {
            _gameInput = new GameInput();

            _gameInput.Gameplay.SetCallbacks(this);

            Enable();
        }

        public void Enable()
        {
            _gameInput.Gameplay.Enable();
        }

        public void Disable()
        {
            _gameInput?.Gameplay.Disable();
        }

        public void OnMove(CallbackContext context)
        {
            MoveInputChanged?.Invoke(context.ReadValue<Vector2>());
        }
    }
}