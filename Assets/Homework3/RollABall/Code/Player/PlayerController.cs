using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerController : IMovable, IUpgradable, ISaveable<PlayerController>
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion


        #region Propeties

        public Rigidbody Rigidbody => _playerModel.Rigidbody;

        public float Speed => _playerModel.Speed;

        public PlayerController Controller => this;

        #endregion


        #region ClassLifeLCycles

        internal PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        #endregion


        #region Methods

        public void ChangeSpeed(float value)
        {
            _playerModel.ImproveSpeed(value);
        }

        #endregion
    }
}