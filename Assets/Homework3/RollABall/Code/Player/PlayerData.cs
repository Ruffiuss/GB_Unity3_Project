using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

    	[SerializeField, Range(GlobalProperties.MIN_PLAYER_SPEED, GlobalProperties.MAX_PLAYER_SPEED)] public float Speed;
    	[SerializeField, Range(GlobalProperties.MIN_PLAYER_MASS, GlobalProperties.MAX_PLAYER_MASS)] public float Mass;
    	[SerializeField, Range(0, 8)] public float Score;
		public GameObject PlayerProvider;

        #endregion
    }
}