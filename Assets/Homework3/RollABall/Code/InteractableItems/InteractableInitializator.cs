using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableInitializator
    {
        #region Fields

        private InteractableController _interactableController;
        private readonly InteractableData _interactableData;

        #endregion


        #region ClassLifeCycles

        internal InteractableInitializator(GameContext gameContext, InteractableData interactableData)
        {
            interactableData.InteractableSpawn = gameContext.InteractableSpawns;

            interactableData.SpawnedInteractable = new List<GameObject>();

            var interactableCount = gameContext.InteractableSpawns.Count;
            var interactableSeter = Divider(interactableCount);

            interactableData.InteractableMap = new Dictionary<ISubInteractable, int>();
            foreach (var type in interactableData.InteractableTypes)
            {
                interactableData.InteractableMap[(ISubInteractable)type] = interactableSeter;
                interactableCount -= interactableSeter;
                interactableSeter = Divider(interactableCount);
            }

            foreach (var key in interactableData.InteractableMap.Keys)
            {
                for (int i = 0; i < interactableData.InteractableMap[key]; i++)
                {
                    var subInitializator = new SubInteractableInitializator(key, interactableData.InteractableSpawn[0]);
                    interactableData.SpawnedInteractable.Add(subInitializator._spawnedObject);
                    interactableData.InteractableSpawn.RemoveAt(0);
                }

            }

            interactableData.UpgradableControllers = new List<IUpgradable>();
            foreach (var controller in gameContext.GetControllers())
            {
                if (controller is IUpgradable)
                {
                    interactableData.UpgradableControllers.Add((IUpgradable)controller);
                }
            }

            _interactableController = new InteractableController(interactableData);
            foreach (var item in interactableData.SpawnedInteractable)
            {
                _interactableController.SubsrcibeView(item.GetComponent<IInteractable>());
            }
        }

        #endregion


        #region Methods

        private int Divider(int value)
        {
            return value / 2;
        }

        internal InteractableController GetController()
        {
            return _interactableController;
        }

        #endregion
    }
}