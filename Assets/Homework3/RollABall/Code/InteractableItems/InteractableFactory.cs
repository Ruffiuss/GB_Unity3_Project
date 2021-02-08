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

        internal InteractableFactory((GameObject provider, float property) info, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(info.provider, position, Quaternion.identity);

            switch (_spawnedObject.GetComponent<IInteractable>())
            {
                case IImprover improve:
                    improve.DefineProperty(info.property);
                    break;
                case IDegrader degrade:
                    degrade.DefineProperty(info.property);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}