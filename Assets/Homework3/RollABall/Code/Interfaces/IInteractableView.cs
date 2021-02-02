using System;
using UnityEngine;


namespace RollABall
{
    public interface IInteractableView
    {
        #region Fields

        event Action<GameObject> DestroyProvider;

        #endregion


        #region UnityMethods

        void OnTriggerEnter(Collider other);
        void OnDestroy();

        #endregion
    }
}