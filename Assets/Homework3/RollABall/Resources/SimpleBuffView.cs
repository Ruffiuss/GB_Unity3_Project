using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IInteractableView, IImprover
    {
        #region Fields

        public event Action<Collider, float> TriggerOnEnter = delegate(Collider collider, float speedBuff) { };
        public event Action<GameObject> DestroyProvider = delegate(GameObject provider) { };

        private float _speedBuff;

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            TriggerOnEnter.Invoke(other, _speedBuff);
            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion


        #region Methods

        public void DefineProperty(float property)
        {
            _speedBuff = property;
        }

        #endregion
    }
}