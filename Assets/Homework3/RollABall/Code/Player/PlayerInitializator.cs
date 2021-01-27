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
            var playerStruct = playerData.playerStruct;

            var spawnedPlayer = Object.Instantiate(playerStruct.PlayerGameObject, playerSpawn, Quaternion.identity);

            _playerController = new PlayerController(new PlayerModel(playerStruct));
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