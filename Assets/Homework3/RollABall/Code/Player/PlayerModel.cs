using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerModel
    {
        #region Fields

        internal PlayerStruct _playerStruct;

        internal Rigidbody _rigidBody;

        #endregion


        #region ClassLifeCycles

        internal PlayerModel(PlayerStruct playerStruct)
        {
            _playerStruct = playerStruct;

            DefineComponets();
        }

        #endregion


        #region Methods

        private void DefineComponets()
        {
            _rigidBody = _playerStruct.PlayerGameObject.GetComponentInChildren<Rigidbody>();
        }

        #endregion
    }
}