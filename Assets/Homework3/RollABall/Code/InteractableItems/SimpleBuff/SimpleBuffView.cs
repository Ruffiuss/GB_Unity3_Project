using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IImprover
    {
        #region Fields

        public event Action<Collider> TriggerOnEnter = delegate(Collider target) { };

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("TRIGGERED");
            TriggerOnEnter.Invoke(other);
        }

        #endregion
    }
}