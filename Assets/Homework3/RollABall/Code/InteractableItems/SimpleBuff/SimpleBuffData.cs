using UnityEngine;
using System;


namespace RollABall
{
    [CreateAssetMenu(fileName = "SimpleBuff", menuName = "Data/SubInteractable/SimpleBuff")]
    public sealed class SimpleBuffData : ScriptableObject
    {
        #region Fields

        public GameObject SimpleBuffGameObject;
        [SerializeField, Range(250, 500)] public float SpeedBuff;

        #endregion
    }
}