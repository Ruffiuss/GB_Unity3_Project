using System;
using UnityEngine;


namespace RollABall
{
    public interface IInteractable
    {
        #region Properties

        event Action<GameObject> DestroyProvider;

        #endregion
    }
}