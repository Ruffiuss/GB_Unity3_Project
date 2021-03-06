using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleDebuffView : MonoBehaviour, IInteractableView, ISpeedChanger
    {
        #region Fields

        public event Action<Collider, IInteractable> SpeedChange = delegate (Collider collider, IInteractable caller) { };
        public event Action<GameObject> DestroyProvider = delegate (GameObject provider) { };

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            SpeedChange.Invoke(other, this);
            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion
    }
}