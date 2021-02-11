using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

    	[SerializeField, Range(400, 1200)] public float Speed;
    	[SerializeField, Range(0.1f, 5.0f)] public float Mass;
		public GameObject PlayerProvider;

        #endregion
    }
}