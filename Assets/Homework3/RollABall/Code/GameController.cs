using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Debug;


namespace RollABall
{
    internal sealed class GameController : MonoBehaviour //changed
    {
        #region Fields

        [SerializeField] private GameData _gameData; //changed
        private Controllers _controllers; //added

        private float _deltaTime;

        //private List<IUpdatable> _iUpdatables = new List<IUpdatable>(); //delete
        //private List<IFixedUpdatable> _iFixedUpdatables = new List<IFixedUpdatable>(); //delete

        #endregion


        #region UnityMethods

        private void Start()
        {
        	_controllers = new Controllers();
            // GameContext gameContext = new GameContext(); // delete
            new InitializeController(_controllers, _gameData);
            _controllers.Initialization();
        }

        private void Update()
        {
        	_deltaTime = Time.deltaTime;
            _controllers.UpdateTick(_deltaTime);
        }
        private void FixedUpdate()
        {
        	_deltaTime = Time.deltaTime;
            _controllers.FixedUpdateTick(_deltaTime);
        }

        private void OnDestroy()
        {
        	//_controllers.Cleanup(); //realize Cleanup Interface and methods in Controllers
        }

        #endregion


        #region Methods

        // TO DELETE
        // internal void AddIUpdatable(IUpdatable updatable)
        // {
        //     _iUpdatables.Add(updatable);
        // }

        // internal void RemoveIUpdatable(IUpdatable updatable)
        // {
        //     _iUpdatables.Remove(updatable);
        // }

        // internal void AddIFixedUpdatable(IFixedUpdatable updatable)
        // {
        //     _iFixedUpdatables.Add(updatable);
        // }

        // internal void RemoveIFixedUpdatable(IFixedUpdatable updatable)
        // {
        //     _iFixedUpdatables.Remove(updatable);
        // }

        #endregion
    }
}