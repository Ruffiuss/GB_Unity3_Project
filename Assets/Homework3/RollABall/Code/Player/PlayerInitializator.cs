using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerInitializator
    {
        #region Fields

        private PlayerController _playerController;
        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeCycles

        internal PlayerInitializator(Transform playerSpawn, PlayerData playerData)
        {
            var spawnedPlayer = Object.Instantiate(playerData.PlayerProvider, playerSpawn.position, Quaternion.identity);
            _playerController = new PlayerController(new PlayerModel(playerData, spawnedPlayer));
        }

        #endregion


        #region Methods

        internal PlayerController GetPlayerController()
        {
            return _playerController;
        }

        #endregion
    }
}