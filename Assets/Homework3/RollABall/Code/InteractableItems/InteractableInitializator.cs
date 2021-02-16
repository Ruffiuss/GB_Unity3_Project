using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableInitializator
    {
        #region Fields

        private InteractableController _interactableController;
        private Queue<Vector3> _spawnQueue;
        private Dictionary<(GameObject, float[]), int> _interactableMap;

        internal event System.Action<GameObject> NewProvider = delegate (GameObject provider) { };

        #endregion


        #region ClassLifeCycles

        internal InteractableInitializator(List<Vector3> interactableSpawns, List<IUpgradable> upgradables, IGameProcessable gameProcess, InteractableData interactableData)
        {
            _spawnQueue = new Queue<Vector3>();
            foreach (var spawn in interactableSpawns)
            {
                _spawnQueue.Enqueue(spawn);
            }

            var interactableModel = new InteractableModel(interactableData, gameProcess);
            interactableModel.SubscribeEvent(this);

            foreach (var upgradable in upgradables)
            {
                interactableModel.AddUpgradable(upgradable);
            }

            DefineInteractableMap(interactableData, _spawnQueue.Count);
            SpawnInteractableElements(interactableModel);

            _interactableController = new InteractableController(interactableModel);
            SetViewListeners(interactableModel.Providers);

            interactableModel.SubscribeEvent(this);
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

        private void DefineInteractableMap(InteractableData data, int count)
        {
            var interactableSeter = Divider(count);
            _interactableMap = new Dictionary<(GameObject, float[]), int>();
            var type = data.GetData(InteractableType.Buff);
            for (int i = 0; i < data.GetDataCount(); i++)
            {
                switch (i)
                {
                    case 0:
                        type = data.GetData(InteractableType.Buff);
                        _interactableMap[type] = interactableSeter;
                        count -= interactableSeter;
                        interactableSeter = Divider(count);
                        break;
                    case 1:
                        type = data.GetData(InteractableType.Debuff);
                        _interactableMap[type] = interactableSeter;
                        count -= interactableSeter;
                        interactableSeter = Divider(count);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SpawnInteractableElements(InteractableModel model)
        {
            foreach (var key in _interactableMap.Keys)
            {
                for (int i = 0; i < _interactableMap[key]; i++)
                {
                    var subInitializator = new InteractableFactory(key, _spawnQueue.Peek());
                    NewProvider.Invoke(subInitializator._spawnedObject);
                    _spawnQueue.Dequeue();
                }
            }
            if (_spawnQueue.Count > 0)
            {
                foreach (var key in _interactableMap.Keys)
                {
                    for(int i = 0; i < _spawnQueue.Count; i++)
                    {
                        var subInitializator = new InteractableFactory(key, _spawnQueue.Peek());
                        NewProvider.Invoke(subInitializator._spawnedObject);
                        _spawnQueue.Dequeue();
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