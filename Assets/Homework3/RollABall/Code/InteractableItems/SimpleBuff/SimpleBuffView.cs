using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IImprover, IInteractableView
    {
        #region Fields

        public event Action<Collider> TriggerOnEnter = delegate(Collider collider) { };
        public event Action<GameObject> DestroyProvider = delegate(GameObject provider) { };

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("TRIGGERED");
            TriggerOnEnter.Invoke(other);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion
    }
}