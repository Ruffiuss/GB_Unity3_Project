using System;
using UnityEngine;

namespace RollABall
{
    public sealed class PCInput : IInputProxy
    {
        public event Action<float, float> AxisOnChage;

        public void GetAxis()
        {
            AxisOnChage.Invoke(Input.GetAxis(InputManager.HORIZONTAL), Input.GetAxis(InputManager.VERTICAL));
        }
    }
}
