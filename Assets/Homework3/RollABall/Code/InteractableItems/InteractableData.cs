using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        public InteractableStruct InteractableStruct;

        #endregion
    }
}