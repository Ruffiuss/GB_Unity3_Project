using UnityEngine;
using System;
using System.Collections.Generic;


namespace RollABall
{
    [Serializable]
    public struct InteractableStruct
    {
        #region Fields

        public GameObject InteractableGameObject;
        public List<GameObject> SpawnedInteractable;
        public Vector3[] InteractableSpawn;

        #endregion
    }
}