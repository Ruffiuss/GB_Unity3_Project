using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableFactory
    {
        #region Fields

        internal GameObject _spawnedObject;

        #endregion


        #region ClassLifeCycles

        internal InteractableFactory((GameObject provider, float[] property) info, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(info.provider, position, Quaternion.identity);

            var interactable = _spawnedObject.GetComponent<IInteractable>();

            if (interactable is ISpeedImprover improve)
            {
                improve.DefineSpeedProperty(info.property[0]);
            }
            if (interactable is ISpeedDegrader degrade)
            {
                degrade.DefineSpeedProperty(info.property[0]);
            }
            if (interactable is IScoreAdder adder)
            {
                adder.DefineScoreProperty((int)info.property[1]);
            }
        }

        #endregion
    }
}