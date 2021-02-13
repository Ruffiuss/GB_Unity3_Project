using UnityEngine;


namespace RollABall
{
    internal sealed class PlayerModel
    {
        #region PrivateData

        private struct PlayerDataCopy
        {
            internal GameObject _playerProvider;
            internal float _speed;
            internal float _mass;
            internal float _score;

        }

        #endregion


        #region Fields

        private PlayerDataCopy _playerDataCopy = new PlayerDataCopy();
        private Rigidbody _rigidbody;

        #endregion


        #region Properties

        internal Rigidbody Rigidbody => _rigidbody;
        internal float Speed => _playerDataCopy._speed;

        #endregion


        #region ClassLifeCycles

        public PlayerModel(PlayerData playerData, GameObject provider)
        {
            _playerDataCopy._playerProvider = provider;
            ParsePlayerData(ref _playerDataCopy, playerData);

            DefineComponents(_playerDataCopy._playerProvider);
        }

        #endregion


        #region Methods

        private void ParsePlayerData(ref PlayerDataCopy playerDataCopy, PlayerData playerData)
        {
            playerDataCopy._speed = playerData.Speed;
            playerDataCopy._mass = playerData.Mass;
            playerDataCopy._score = playerData.Score;
        }

        private void DefineComponents(GameObject provider)
        {
            _rigidbody = provider.GetComponentInChildren<Rigidbody>();
            _rigidbody.mass = _playerDataCopy._mass;
        }

        internal void ImproveSpeed(float value)
        {
            _playerDataCopy._speed = _playerDataCopy._speed < 5000 ? _playerDataCopy._speed + value : _playerDataCopy._speed;
        }

        internal void ImproveScore(int value)
        {
            _playerDataCopy._score += value;
            if (_playerDataCopy._score >= GlobalProperties.SCORE_TO_WIN)
            {
                Debug.Log("U WON");
            }
        }

        #endregion
    }
}
