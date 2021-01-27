namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(Controllers controllers, GameData gameData)
        {
            var levelInitialized = new LevelInitializator(gameData.Level);

            var playerInitialized = new PlayerInitializator(levelInitialized.GetPlayerSpawn(), gameData.Player);
            controllers.Add(playerInitialized.GetPlayer());

            var interactableInitialized = new InteractableInitializator(levelInitialized.GetInteractableSpawns(), _controllers.GetUpgradables(), gameData.Interactable); // changed
            _controllers.Add(interactableInitialized.GetController());
        }

        #endregion
    }
}