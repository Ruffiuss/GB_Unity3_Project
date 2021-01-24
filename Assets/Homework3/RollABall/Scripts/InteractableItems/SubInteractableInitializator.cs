using UnityEngine;


namespace RollABall
{
    internal sealed class SubInteractableInitializator
    {
        #region Fields

        internal GameObject _spawnedObject;

        #endregion


        #region ClassLifeCycles

        internal SubInteractableInitializator(ISubInteractable subInteractable, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(subInteractable.SubInteractableView, position, Quaternion.identity);
        }

        #endregion
    }
}