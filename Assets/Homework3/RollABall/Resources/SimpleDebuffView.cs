using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleDebuffView : MonoBehaviour, IInteractableView, IDegrader
    {
        #region Fields

        public event Action<Collider, float> TriggerOnEnter = delegate (Collider collider, float speddDebuff) { };
        public event Action<GameObject> DestroyProvider = delegate (GameObject provider) { };

        private float _speedDebuff;

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            TriggerOnEnter.Invoke(other, _speedDebuff);
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
            _speedDebuff = property;
        }

        #endregion
    }
}