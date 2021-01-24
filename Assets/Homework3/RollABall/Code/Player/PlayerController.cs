using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerController : IFixedUpdatable, IDegradable, IImprovable
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeLCycles

        internal PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        #endregion


        #region Methods

        public void FixedUpdateTick()
        {
            Move();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _playerModel._rigidBody.AddForce(movement * _playerModel._playerStruct.Speed);
        }

        public void ImproveSpeed(float value)
        {
            if (_playerModel._playerStruct.Speed < 100)
            {
                _playerModel._playerStruct.Speed += value;
            }
        }

        #endregion
    }
}