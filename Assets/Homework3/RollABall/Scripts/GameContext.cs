using UnityEngine;


namespace RollABall
{
    internal class GameContext
    {
        #region Fields

        private Vector3 _playerSpawn = Vector3.zero;

        #endregion


        #region Properties

        internal Vector3 PlayerSpawn
        {
            get
            {
                return _playerSpawn;
            }
            private set 
            {
                _playerSpawn = value;
            }
        }

        #endregion


        #region Methods

        internal void SetPlayerSpawn(Vector3 spawnPosition)
        {
            PlayerSpawn = spawnPosition;
        }

        #endregion
    }
}