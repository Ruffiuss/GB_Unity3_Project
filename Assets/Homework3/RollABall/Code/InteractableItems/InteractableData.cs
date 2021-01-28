using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


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
            public IInteractableView View;
        }

        [SerializeField] private List<InteractableInfo> _interactableInfos;

        #endregion


        #region Methods

        public (GameObject provider, IInteractableView view) GetData(InteractableType type)
        {
            var interactableInfo = _interactableInfos.First(info => info.Type == type);
            return (interactableInfo.Provider, interactableInfo.View);
        }

        public int GetDataCount()
        {
            return _interactableInfos.Count;
        }

        #endregion
    }
}