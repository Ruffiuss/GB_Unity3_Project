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
        internal InteractableFactory((GameObject provider, string viewPath, float property) info, Vector3 position)
        {
            _spawnedObject = Object.Instantiate(info.provider, position, Quaternion.identity);

            switch (UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(_spawnedObject, info.viewPath, info.viewPath))
            {
                case IImprover b:
                    b.DefineProperty(info.property);
                    break;
                case IDegrader b:
                    b.DefineProperty(info.property);
                    break;
                default:
                    break;
            }

        }

        #endregion
    }
}