using UnityEngine;
using System;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy")]
    public sealed class EnemyData : UnityEngine.ScriptableObject
    {
        #region Fields

        public EnemyStruct EnemyStruct;

        #endregion
    }
}