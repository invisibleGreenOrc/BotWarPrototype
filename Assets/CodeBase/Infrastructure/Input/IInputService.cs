using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Input
{
    public interface IInputService
    {
        event Action<Vector2> MoveInputChanged;
        
        void Enable();

        void Disable();
    }
}