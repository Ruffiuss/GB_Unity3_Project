using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public sealed class PlayerData : UnityEngine.ScriptableObject
    {
        #region Fields

    	[SerializeField, Range(0, 100)] private float _speed;
		public GameObject PlayerProvider;

        #endregion


        #region Properties

    	public float Speed => _speed;

    	#endregion
    }
}