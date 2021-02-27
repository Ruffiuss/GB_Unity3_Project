using System;
using UnityEngine;


namespace RollABall
{
    public interface IInputProxy
    {
        event Action<float, float> AxisOnChage;
        event Action<bool> RestartOnPressed;
        event Action<bool> EscapeOnPressed;
        event Action<bool> SavePlayerPosition;
        event Action<bool> LoadPlayerPosition;
        void GetAxisChanged();
        void GetKeyPressed();
    }
}