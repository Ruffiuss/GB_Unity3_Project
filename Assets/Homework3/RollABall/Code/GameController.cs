using UnityEngine;


namespace RollABall
{
    internal sealed class GameController : MonoBehaviour, IControllable
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
            new InitializeController(_controllers, _gameData, this);
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
        	_controllers.Cleanup();
        }

        internal void ListenToRestart(IInputProxy input)
        {
            input.RestartOnPressed += Restart;
        }

        private void Restart(bool value)
        {
            if (value)
            {
                gameObject.AddComponent<GameController>()._gameData = _gameData;
                Destroy(this);
                
            }
        }

        #endregion
    }
}