using System;
using UnityEngine;


namespace RollABall
{
    public sealed class PCInput : IInputProxy
    {
        public event Action<float, float> AxisOnChage;
        public event Action<bool> RestartOnPressed;
        public event Action<bool> EscapeOnPressed;
        public event Action<bool> SavePlayerPosition;
        public event Action<bool> LoadPlayerPosition;

        public void GetAxisChanged()
        {
            AxisOnChage.Invoke(Input.GetAxis(InputManager.HORIZONTAL), Input.GetAxis(InputManager.VERTICAL));
        }

        public void GetKeyPressed()
        {
            if (Input.GetKeyDown(InputManager.RESTART))
            {
                RestartOnPressed.Invoke(true);
            }
            if (Input.GetKeyDown(InputManager.ESCAPE))
            {
                EscapeOnPressed.Invoke(true);
            }
            if (Input.GetKeyDown(InputManager.SAVE_PLAYER_POSITION))
            {
                SavePlayerPosition.Invoke(true);
            }
            if (Input.GetKeyDown(InputManager.LOAD_PLAYER_POSITON))
            {
                LoadPlayerPosition.Invoke(true);
            }
        }
    }
}