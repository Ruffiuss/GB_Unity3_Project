using UnityEngine;
using System;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy")]
    public class EnemyData : ScriptableObject
    {
        #region Fields

        public EnemyStruct EnemyStruct;

        #endregion
    }
}