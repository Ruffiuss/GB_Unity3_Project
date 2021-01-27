using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerInitializator
    {
        #region Fields

        private PlayerController _playerController;

        #endregion


        #region ClassLifeCycles

        internal PlayerInitializator(Transform playerSpawn, PlayerData playerData)
        {
            var spawnedPlayer = Object.Instantiate(playerData.PlayerGameObject, playerSpawn, Quaternion.identity);
        	playerData.PlayerProvider = spawnedPlayer;
            _playerController = new PlayerController(playerData);
        }

        #endregion


        #region Methods

        internal PlayerController GetPlayer()
        {
            return _playerController;
        }

        #endregion
    }
}