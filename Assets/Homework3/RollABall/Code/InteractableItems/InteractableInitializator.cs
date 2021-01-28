using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableInitializator
    {
        #region Fields

        private InteractableController _interactableController;
        private List<Vector3> _interactableSpawns;
        private Dictionary<ISubInteractable, int> _interactableMap;

        #endregion


        #region ClassLifeCycles

        internal InteractableInitializator(List<Vector3> interactableSpawns, List<IUpgradable> upgradables, InteractableData interactableData)
        {
            _interactableSpawns = new List<Vector3>();
            _interactableSpawns = interactableSpawns;
            var subInteractableProviders = new List<GameObject>();

            DefineInteractableMap(interactableData.InteractableTypes);
            SpawnInteractableElements(ref subInteractableProviders);

            _interactableController = new InteractableController(subInteractableProviders, upgradables);
            SetViewListeners(subInteractableProviders);
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

        private void DefineInteractableMap(List<ScriptableObject> types)
        {
            var interactableCount = _interactableSpawns.Count;
            var interactableSeter = Divider(interactableCount);
            _interactableMap = new Dictionary<ISubInteractable, int>();
            foreach (var type in types)
            {
                _interactableMap[(ISubInteractable)type] = interactableSeter;
                interactableCount -= interactableSeter;
                interactableSeter = Divider(interactableCount);
            }
        }

        private void SpawnInteractableElements(ref List<GameObject> subInteractableProviders)
        {
            foreach (var key in _interactableMap.Keys)
            {
                for (int i = 0; i < _interactableMap[key]; i++)
                {
                    var subInitializator = new SubInteractableInitializator(key, _interactableSpawns[0]);
                    subInteractableProviders.Add(subInitializator._spawnedObject);
                    _interactableSpawns.RemoveAt(0);
                }

            }
        }

        private void SetViewListeners(List<GameObject> subInteractableProviders)
        {
            foreach (var item in subInteractableProviders)
            {
                _interactableController.SubsrcibeView(item.GetComponent<IInteractable>());
            }
        }

        #endregion
    }
}