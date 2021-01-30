using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableFactory
    {
        #region Fields

        internal GameObject _spawnedObject;

        #endregion


        #region ClassLifeCycles

        [System.Obsolete]
        internal InteractableFactory((GameObject provider, string viewPath) info, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(info.provider, position, Quaternion.identity);
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(_spawnedObject, info.viewPath, info.viewPath);
        }

        #endregion
    }
}