using UnityEngine;
using System;
using System.Collections.Generic;


namespace RollABall
{
    [Serializable]
    public struct InteractableStruct
    {
        #region Fields

        public List<GameObject> SpawnedInteractable;
        public List<ScriptableObject> InteractableTypes;
        public Dictionary<ISubInteractable, int> InteractableMap;
        public List<Vector3> InteractableSpawn;

        #endregion
    }
}