namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(GameController gameController, GameContext gameContext, GameData gameData)
        {
            new LevelInitializator(gameController, gameContext, gameData.gameStruct.Level);
            new PlayerInitializator(gameController, gameContext, gameData.gameStruct.Player);
            new InteractableInitializator(gameController, gameContext, gameData.gameStruct.Interactable);
        }

        #endregion
    }
}