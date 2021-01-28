using UnityEngine;
using System;


namespace RollABall
{ 
    [CreateAssetMenu( fileName = "SimpleBuff", menuName = "Data/SubInteractable/SimpleBuff")]
    public sealed class SimpleBuffData : ScriptableObject
    {
        #region Fields

        public GameObject SimpleBuffGameObject;
        [SerializeField, Range(1, 100)] public float SpeedBuff;

        #endregion
    }
}