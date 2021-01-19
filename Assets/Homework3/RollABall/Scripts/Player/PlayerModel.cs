using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerModel : IUpdatable, IDegradable, IImprovable
    {
        #region Fields

        private Rigidbody _rigidBody;
        private PlayerStruct _playerStruct;

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

        public void UpdateTick()
        {
            _playerStruct.PlayerGameObject.transform.position +=
                 _playerStruct.PlayerGameObject.transform.forward *
                5.0f * Time.deltaTime;
        }

        #endregion
    }
}