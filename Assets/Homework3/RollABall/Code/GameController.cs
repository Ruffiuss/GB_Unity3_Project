using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Debug;


namespace RollABall
{
    internal sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameData _gameData;
        private Controllers _controllers;

        private float _deltaTime;
        private float _fixedDeltaTime;

        #endregion


        #region UnityMethods

        private void Start()
        {
        	_controllers = new Controllers();
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
        	_fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedUpdateTick(_fixedDeltaTime);
        }

        private void OnDestroy()
        {
        	//_controllers.Cleanup(); //realize Cleanup Interface and methods in Controllers
        }

        #endregion
    }
}