using UnityEngine;


namespace RollABall
{
    internal class GameContext
    {
        #region Fields

        private Vector3 _playerSpawn = Vector3.zero;
        private Vector3[] _interactableSpawns;

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

        internal Vector3[] InteractableSpawns
        {
            get
            {
                return _interactableSpawns;
            }
        }

        #endregion


        #region Methods

        internal void SetPlayerSpawn(Vector3 spawnPosition)
        {
            PlayerSpawn = spawnPosition;
        }

        internal void SetInteractableSpawns(Vector3[] interactableSpawns)
        {
            _interactableSpawns = new Vector3[interactableSpawns.Length];
            for (int i = 0; i < _interactableSpawns.Length; i++)
            {
                _interactableSpawns[i] = interactableSpawns[i];
            }
        }
      
        #endregion
    }
}