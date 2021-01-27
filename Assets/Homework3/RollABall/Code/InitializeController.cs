namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(Controllers controllers, GameData gameData) //changed
        {
            var levelInitialized = new LevelInitializator(gameData.gameStruct.Level); //changed

            var playerInitialized = new PlayerInitializator(levelInitialized.GetPlayerSpawn(), gameData.gameStruct.Player); // changed
            controllers.Add(playerInitialized.GetPlayer()); //changed

            var interactableInitialized = new InteractableInitializator(levelInitialized.GetInteractableSpawns(), _controllers.GetUpgradables(), gameData.gameStruct.Interactable); // changed
            _controllers.Add(interactableInitialized.GetController()); // changed
            // gameController.AddIUpdatable(interactableInitialized.GetController()); // deleted
        }

        #endregion
    }
}