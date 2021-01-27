namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(Controllers controllers, GameData gameData)
        {
            var levelInitialized = new LevelInitializator(gameData.gameStruct.Level);

            var playerInitialized = new PlayerInitializator(levelInitialized.GetPlayerSpawn(), gameData.gameStruct.Player);
            controllers.Add(playerInitialized.GetPlayer());

            var interactableInitialized = new InteractableInitializator(levelInitialized.GetInteractableSpawns(), _controllers.GetUpgradables(), gameData.gameStruct.Interactable); // changed
            _controllers.Add(interactableInitialized.GetController());
        }

        #endregion
    }
}