using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IInteractableView, ISpeedChanger, IScoreChanger
    {
        #region Fields

        public event Action<Collider, IInteractable> SpeedChange = delegate(Collider collider, IInteractable caller) { };
        public event Action<GameObject> DestroyProvider = delegate(GameObject provider) { };
        public event Action<bool, IInteractable> AddScore = delegate (bool isTrigger, IInteractable caller) { };

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            SpeedChange.Invoke(other, this);
            AddScore.Invoke(true, this);
            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion
    }
}