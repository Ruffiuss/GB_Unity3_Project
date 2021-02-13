using UnityEngine;
using System;


namespace RollABall
{
    [CreateAssetMenu(fileName = "SimpleDebuff", menuName = "Data/SubInteractable/SimpleDebuff")]
    public sealed class SimpleDebuffData : ScriptableObject
    {
        #region Fields

        public GameObject SimpleDebuffGameObject;
        [SerializeField, Range(GlobalProperties.MIN_SPEEDBUFF, GlobalProperties.MAX_SPEEDBUFF)] public float SpeedDebuff;

        #endregion
    }
}