using System;
using UnityEngine;


namespace RollABall
{
    [Serializable]
    public struct LevelStruct
    {
        public GameObject LevelGameObject;
        public Vector3 PlayerSpawn;
        public Vector3[] InteractablePositions;
        public Vector3[] EnemyPositions;
    }
}