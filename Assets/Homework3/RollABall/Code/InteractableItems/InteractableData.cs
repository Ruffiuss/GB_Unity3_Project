using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        [Serializable]
        internal struct InteractableInfo
        {
            [SerializeField]internal SimpleBuffData Buff;
            [SerializeField]internal SimpleDebuffData Debuff;
        }

        [Serializable]
        internal class SimpleBuffData : IInteractableData
        {
            [SerializeField] private GameObject _provider;
            [SerializeField, Range(GlobalProperties.MIN_SPEEDBUFF, GlobalProperties.MAX_SPEEDBUFF)] private float _speedBuff;
            [SerializeField, Range(1, 10)] private float _scoreBuff;
            private byte _checker;
            public GameObject Provider { get => _provider; }
            public float[] Property 
            {
                get { return new float[2] { _speedBuff, _scoreBuff }; }
            }
        }

        [Serializable]
        internal class SimpleDebuffData : IInteractableData
        {
            [SerializeField] private GameObject _provider;
            [SerializeField, Range(GlobalProperties.MAX_SPEEDBUFF * -1, GlobalProperties.MIN_SPEEDBUFF * -1)] private float _speedDebuff;
            public GameObject Provider { get => _provider; }
            public float[] Property { get => new float[1] { _speedDebuff }; }
        }

        [SerializeField] internal InteractableInfo _interactableInfo;
        internal Dictionary<InteractableType, IInteractableData> _interactableDataDictionary;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _interactableDataDictionary = new Dictionary<InteractableType, IInteractableData>() { { InteractableType.Buff, _interactableInfo.Buff }, { InteractableType.Debuff, _interactableInfo.Debuff } };
        }

        #endregion


        #region Methods

        internal int GetDataCount()
        {
            return _interactableDataDictionary.Count;
        }

        internal IInteractableData GetTypeData(InteractableType type)
        {
            return _interactableDataDictionary[type];
        }

        internal List<IInteractableData> GetData()
        {
            return _interactableDataDictionary.GetValueList();
        }

        #endregion
    }
}