using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerController : IMovable, IDegradable, IImprovable
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion


        #region Propeties

        public Rigidbody Rigidbody => _playerModel.Rigidbody;

        public float Speed => _playerModel.Speed;

        #endregion


        #region ClassLifeLCycles

        internal PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        #endregion


        #region Methods


        public void ImproveSpeed(float value)
        {
            _playerModel.ImproveSpeed(value);
        }

        public void ImproveScore(int value)
        {
            _playerModel.ImproveScore(value);
        }

        #endregion
    }
}