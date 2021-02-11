using UnityEngine;
using System;


namespace RollABall
{
    [CreateAssetMenu(fileName = "SimpleDebuff", menuName = "Data/SubInteractable/SimpleDebuff")]
    public sealed class SimpleDebuffData : ScriptableObject
    {
        #region Fields

        public GameObject SimpleDebuffGameObject;
        [SerializeField, Range(250, 500)] public float SpeedDebuff;

        #endregion
    }
}