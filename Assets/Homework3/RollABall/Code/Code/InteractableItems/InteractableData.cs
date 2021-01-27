using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactable")]
    public sealed class InteractableData : ScriptableObject
    {
        #region Fields

        public List<ScriptableObject> InteractableTypes;
        public Dictionary<ISubInteractable, int> InteractableMap;
        public List<Vector3> InteractableSpawn;
        public List<GameObject> SpawnedInteractable;
        public List<IUpgradable> UpgradableControllers;

        #endregion
    }
}