using UnityEngine;
using System.Collections.Generic;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        public List<ScriptableObject> InteractableTypes;
        internal Dictionary<ISubInteractable, int> InteractableMap;
        internal List<Vector3> InteractableSpawn;
        internal List<GameObject> SpawnedInteractable;
        internal List<IUpgradable> UpgradableControllers;

        #endregion
    }
}