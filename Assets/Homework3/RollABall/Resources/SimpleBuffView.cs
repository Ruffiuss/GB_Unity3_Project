using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IInteractableView, IImprover
    {
        #region Fields

        public event Action<Collider> TriggerOnEnter = delegate(Collider collider) { };
        public event Action<GameObject> DestroyProvider = delegate(GameObject provider) { };
        public event Action<float> SpeedImprover = delegate(float provider) { };

        private float _speedBuff;

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            TriggerOnEnter.Invoke(other);
            SpeedImprover.Invoke(_speedBuff);
            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion
    }
}