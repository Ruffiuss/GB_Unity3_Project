using UnityEngine;
using System.Collections.Generic;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        public List<ScriptableObject> InteractableTypes;

        #endregion
    }
}