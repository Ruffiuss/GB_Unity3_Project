namespace RollABall
{
    internal sealed class InitializeController
    {
        #region ClassLifeCycles

        internal InitializeController(Controllers controllers, GameData gameData, GameController gameController)
        {
            var levelInitialized = new LevelInitializator(gameData.Level);

            var inputInitialized = new InputInitializator();
            controllers.Add(new InputController(inputInitialized.GetInput()));

            var playerInitialized = new PlayerInitializator(levelInitialized.GetPlayerSpawn(), gameData.Player);
            controllers.Add(playerInitialized.GetPlayerController());
            controllers.Add(new MoveController(inputInitialized.GetInput(), playerInitialized.GetPlayerController()));
            gameController.ListenToRestart(inputInitialized.GetInput());

            var saverInitialized = new SaveController(inputInitialized.GetInput(), playerInitialized.GetPlayerController());

            var interactableInitialized = new InteractableInitializator(levelInitialized.GetInteractableSpawns(), controllers.GetUpgradables(), controllers.GetGameProcessController(), gameData.Interactable);
            controllers.Add(interactableInitialized.GetController());

            var gameUIInitialized = new UIInitializator(gameData.UI);
            gameUIInitialized.SubscribeGameProcess(controllers.GetGameProcessController());
            controllers.Add(gameUIInitialized.GetUIController());
        }

        #endregion
    }
}