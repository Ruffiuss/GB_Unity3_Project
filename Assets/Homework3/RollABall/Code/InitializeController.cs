namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(GameController gameController, GameContext gameContext, GameData gameData)
        {
            var levelInitialized = new LevelInitializator(gameController, gameContext, gameData.gameStruct.Level);

            var playerInitialized = new PlayerInitializator(gameController, gameContext, gameData.gameStruct.Player);
            gameContext.AddController(playerInitialized.GetPlayer());

            var interactableInitialized = new InteractableInitializator(gameContext, gameData.gameStruct.Interactable);
            gameContext.AddController(interactableInitialized.GetController());
            gameController.AddIUpdatable(interactableInitialized.GetController());
        }

        #endregion
    }
}