using System;
using UnityEngine;


namespace RollABall
{
    public interface IImprover : IInteractable
    {
        #region Properties

        event Action<Collider> TriggerOnEnter;
        event Action<GameObject> DestroyProvider;

        #endregion
    }
}