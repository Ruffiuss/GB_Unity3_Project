namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(Controllers controllers, GameData gameData)
        {
            var levelInitialized = new LevelInitializator(gameData.Level);

            var inputInitialized = new InputInitializator();
            controllers.Add(new InputController(inputInitialized.GetInput()));

            var playerInitialized = new PlayerInitializator(levelInitialized.GetPlayerSpawn(), gameData.Player);
            controllers.Add(playerInitialized.GetPlayerController());
            controllers.Add(new MoveController(inputInitialized.GetInput(), playerInitialized.GetPlayerController()));

            var interactableInitialized = new InteractableInitializator(levelInitialized.GetInteractableSpawns(), controllers.GetUpgradables(), gameData.Interactable);
            controllers.Add(interactableInitialized.GetController());

            var gameUIInitialized = new UIInitializator(gameData.UI);
            controllers.Add(gameUIInitialized.GetUIController());
        }

        #endregion
    }
}