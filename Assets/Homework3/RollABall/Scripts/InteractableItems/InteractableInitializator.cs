using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableInitializator
    {
        #region ClassLifeCycles

        internal InteractableInitializator(GameController gameController, GameContext gameContext, InteractableData interactableData)
        {
            var interactableStruct = interactableData.InteractableStruct;

            interactableStruct.InteractableSpawn = gameContext.InteractableSpawns;

            interactableStruct.SpawnedInteractable = new List<GameObject>();

            var interactableCount = gameContext.InteractableSpawns.Count;
            var interactableSeter = Divider(interactableCount);

            interactableStruct.InteractableMap = new Dictionary<ISubInteractable, int>();

            foreach (var item in interactableStruct.InteractableTypes)
            {
                interactableStruct.InteractableMap[(ISubInteractable)item] = interactableSeter;
                interactableCount -= interactableSeter;
                interactableSeter = Divider(interactableCount);
            }

            foreach (var item in interactableStruct.InteractableMap.Keys)
            {
                for (int i = 0; i < interactableStruct.InteractableMap[item]; i++)
                {
                    var subInitializator = new SubInteractableInitializator(item, interactableStruct.InteractableSpawn[0]);
                    interactableStruct.SpawnedInteractable.Add(subInitializator._spawnedObject);
                    interactableStruct.InteractableSpawn.RemoveAt(0);
                }

            }

            var interactableController = new InteractableController(new InteractableModel(interactableStruct));

            gameContext.AddController(interactableController);
            gameController.AddIUpdatable(interactableController);
        }

        #endregion


        #region Methods

        private int Divider(int value)
        {
            return value / 2;
        }

        #endregion
    }
}