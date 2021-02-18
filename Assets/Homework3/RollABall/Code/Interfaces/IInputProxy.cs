using System;
using UnityEngine;


namespace RollABall
{
    public interface IInputProxy
    {
        event Action<float, float> AxisOnChage;
        event Action<bool> RestartOnPressed;
        event Action<bool> EscapeOnPressed;
        void GetAxisChanged();
        void GetKeyPressed();
    }
}