using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
    internal sealed class GameData : ScriptableObject
    {
        #region Fields

        public GameStruct gameStruct;

        #endregion
    }
}