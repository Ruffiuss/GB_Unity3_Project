using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerInitializator
    {
        #region Fields

        private PlayerController _playerController;

        #endregion


        #region ClassLifeCycles

        internal PlayerInitializator(GameController gameController, GameContext gameContext, PlayerData playerData)
        {
            var playerStruct = playerData.playerStruct;

            var spawnedPlayer = Object.Instantiate(playerStruct.PlayerGameObject, gameContext.PlayerSpawn, Quaternion.identity);
            playerStruct.PlayerGameObject = spawnedPlayer;

            _playerController = new PlayerController(new PlayerModel(playerStruct));

            gameController.AddIFixedUpdatable(_playerController);
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