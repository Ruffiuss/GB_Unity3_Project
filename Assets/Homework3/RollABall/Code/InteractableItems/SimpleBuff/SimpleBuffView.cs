using System;
using UnityEngine;


namespace RollABall
{
    public sealed class SimpleBuffView : MonoBehaviour, IInteractableView, ISpeedImprover, IScoreAdder
    {
        #region Fields

        public event Action<Collider, float> SpeedImprove = delegate(Collider collider, float speedBuff) { };
        public event Action<GameObject> DestroyProvider = delegate(GameObject provider) { };
        public event Action<int> AddScore = delegate(int scorePoints) { };

        private float _speedBuff;
        private int _scorePoints;

        #endregion


        #region UnityMethods

        public void OnTriggerEnter(Collider other)
        {
            SpeedImprove.Invoke(other, _speedBuff);
            AddScore.Invoke(_scorePoints);
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
            _speedBuff = speedProp;
        }

        public void DefineScoreProperty(int scoreProp)
        {
            _scorePoints = scoreProp;
        }

        #endregion
    }
}