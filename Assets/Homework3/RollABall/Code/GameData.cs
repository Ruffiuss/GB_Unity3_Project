using System.IO;
using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
    public sealed class GameData : UnityEngine.ScriptableObject
    {
        #region Fields

        [SerializeField] private string _levelDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _interactableDataPath;
        private LevelData _level;
        private PlayerData _player;
        private InteractableData _interactable;

        #endregion


        #region Properties

        public LevelData Level
        {
            get
            {
                if (_level == null)
                {
                    _level = Load<LevelData>("Data/" + _levelDataPath);
                }

                return _level;
            }
        }

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }

        public InteractableData Interactable
        {
            get
            {
                if (_interactable == null)
                {
                    _interactable = Load<InteractableData>("Data/" + _interactableDataPath);
                }

                return _interactable;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

        #endregion
    }
}