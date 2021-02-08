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
        private struct InteractableInfo
        {
            public InteractableType Type;
            public GameObject Provider;
            public float Property;
        }

        [SerializeField] private List<InteractableInfo> _interactableInfos;

        #endregion


        #region Methods

        public (GameObject provider, float property) GetData(InteractableType type)
        {
            var interactableInfo = _interactableInfos.First(info => info.Type == type);
            return (interactableInfo.Provider, interactableInfo.Property);
        }

        public int GetDataCount()
        {
            return _interactableInfos.Count;
        }

        #endregion
    }
}