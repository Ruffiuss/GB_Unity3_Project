using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

        public PlayerStruct playerStruct;

        #endregion
    }
}
