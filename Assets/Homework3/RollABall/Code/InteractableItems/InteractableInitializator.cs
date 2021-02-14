using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableInitializator
    {
        #region Fields

        private InteractableController _interactableController;
        private List<Vector3> _interactableSpawns;
        private Dictionary<(GameObject, float[]), int> _interactableMap;

        #endregion


        #region ClassLifeCycles

        internal InteractableInitializator(List<Vector3> interactableSpawns, List<IUpgradable> upgradables, IGameProcessable gameProcess, InteractableData interactableData)
        {
            _interactableSpawns = new List<Vector3>();
            _interactableSpawns = interactableSpawns;
            var subInteractableProviders = new List<GameObject>();

            DefineInteractableMap(interactableData);
            SpawnInteractableElements(ref subInteractableProviders);

            _interactableController = new InteractableController(subInteractableProviders, upgradables, gameProcess);
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

        private void DefineInteractableMap(InteractableData data)
        {
            var interactableCount = _interactableSpawns.Count;
            var interactableSeter = Divider(interactableCount);
            _interactableMap = new Dictionary<(GameObject, float[]), int>();
            var type = data.GetData(InteractableType.Buff);
            for (int i = 0; i < data.GetDataCount(); i++)
            {
                switch (i)
                {
                    case 0:
                        type = data.GetData(InteractableType.Buff);
                        _interactableMap[type] = interactableSeter;
                        interactableCount -= interactableSeter;
                        interactableSeter = Divider(interactableCount);
                        break;
                    case 1:
                        type = data.GetData(InteractableType.Debuff);
                        _interactableMap[type] = interactableSeter;
                        interactableCount -= interactableSeter;
                        interactableSeter = Divider(interactableCount);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SpawnInteractableElements(ref List<GameObject> subInteractableProviders)
        {
            foreach (var key in _interactableMap.Keys)
            {
                for (int i = 0; i < _interactableMap[key]; i++)
                {
                    var subInitializator = new InteractableFactory(key, _interactableSpawns[0]);
                    subInteractableProviders.Add(subInitializator._spawnedObject);
                    _interactableSpawns.RemoveAt(0);
                }
            }
            if (_interactableSpawns.Count > 0)
            {
                foreach (var key in _interactableMap.Keys)
                {
                    for(int i = 0; i < _interactableSpawns.Count; i++)
                    {
                        var subInitializator = new InteractableFactory(key, _interactableSpawns[0]);
                        subInteractableProviders.Add(subInitializator._spawnedObject);
                        _interactableSpawns.RemoveAt(0);
                    }
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