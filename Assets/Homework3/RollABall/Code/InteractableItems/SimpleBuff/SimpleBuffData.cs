using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "SimpleBuff", menuName = "Data/SubInteractable/SimpleBuff")]
    public sealed class SimpleBuffData : ScriptableObject
    {
        #region Fields

        public GameObject SimpleBuffGameObject;
        [SerializeField, Range(GlobalProperties.MIN_SPEEDBUFF, GlobalProperties.MAX_SPEEDBUFF)] public float SpeedBuff;

        #endregion
    }
}