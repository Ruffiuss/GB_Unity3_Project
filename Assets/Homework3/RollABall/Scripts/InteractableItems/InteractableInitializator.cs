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

            GameObject spawnedInteracatble = null;
            var interactableCount = gameContext.InteractableSpawns.Length;
            interactableStruct.SpawnedInteractable = new List<GameObject>();

            for (var i = 0; i < interactableCount; i++)
            {
                spawnedInteracatble = Object.Instantiate(interactableStruct.InteractableGameObject, gameContext.InteractableSpawns[i], Quaternion.identity);
                interactableStruct.SpawnedInteractable.Add(spawnedInteracatble);
            }

            var interactableModel = new InteractableSimpleBuffModel(interactableStruct);

            gameController.AddIUpdatable(interactableModel);
        }

        #endregion
    }
}