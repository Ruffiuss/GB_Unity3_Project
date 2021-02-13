using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleDebuffView : MonoBehaviour, IInteractableView, ISpeedDegrader
    {
        #region Fields

        public event Action<Collider, float> SpeedDegrade = delegate (Collider collider, float speddDebuff) { };
        public event Action<GameObject> DestroyProvider = delegate (GameObject provider) { };

        private float _speedDebuff;

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            SpeedDegrade.Invoke(other, _speedDebuff);
            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            DestroyProvider.Invoke(gameObject);
        }

        #endregion


        #region Methods

        public void DefineSpeedProperty(float speedProp)
        {
            _speedDebuff = speedProp;
        }

        #endregion
    }
}