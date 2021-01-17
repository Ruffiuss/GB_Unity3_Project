using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerInitializator
    {
        #region ClassLifeCycles

        internal PlayerInitializator(GameController gameController, GameContext gameContext, PlayerData playerData)
        {
            var playerStruct = playerData.playerStruct;

            var spawnedPlayer = Object.Instantiate(playerStruct.PlayerGameObject, gameContext.PlayerSpawn ,Quaternion.identity);
            playerStruct.PlayerGameObject = spawnedPlayer;

            var playerModel = new PlayerModel(playerStruct);

            new PlayerController(playerModel);

            gameController.AddIUpdatable(playerModel);
        }

        #endregion
    }
}