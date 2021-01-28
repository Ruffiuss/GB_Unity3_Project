using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableFactory
    {
        #region Fields

        private readonly InteractableData _data;
        internal GameObject _spawnedObject;

        #endregion


        #region ClassLifeCycles

        internal InteractableFactory(GameObject provider, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(provider, position, Quaternion.identity);
        }

        #endregion
    }
}