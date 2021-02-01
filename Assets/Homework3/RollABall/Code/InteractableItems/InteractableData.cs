using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace RollABall
{
    [CustomEditor(typeof(IInteractableView), true)]
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        [Serializable]
        private struct InteractableInfo
        {
            public InteractableType Type;
            public GameObject Provider;
            public string ViewPath;
        }

        [SerializeField] private List<InteractableInfo> _interactableInfos;

        #endregion


        #region Methods

        public (GameObject provider, string view) GetData(InteractableType type)
        {
            var interactableInfo = _interactableInfos.First(info => info.Type == type);
            return (interactableInfo.Provider, interactableInfo.ViewPath);
        }

        public int GetDataCount()
        {
            return _interactableInfos.Count;
        }

        #endregion
    }
}