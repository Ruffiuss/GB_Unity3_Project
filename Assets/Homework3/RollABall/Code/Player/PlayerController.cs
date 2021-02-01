using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerController : IFixedUpdatable, IDegradable, IImprovable
    {
        #region Fields

        private GameObject _playerProvider;
        private Rigidbody _rigidBody;
        private float _speed;

        #endregion


        #region ClassLifeLCycles

        internal PlayerController(PlayerData playerData, GameObject playerProvider)
        {
            _playerProvider = playerProvider;
            _speed = playerData.Speed;
            _rigidBody = _playerProvider.GetComponentInChildren<Rigidbody>();
        }

        #endregion


        #region Methods

        public void FixedUpdateTick(float deltaTime)
        {
            Debug.Log(_speed);
            Debug.Log($"{_playerProvider}|{_rigidBody}");
            Move();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidBody.AddForce(movement * _speed);
        }

        public void ImproveSpeed(float value)
        {
            if (_speed < 100)
            {
                _speed += value;
            }
        }

        #endregion
    }
}