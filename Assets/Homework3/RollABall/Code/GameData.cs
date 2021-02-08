using System.IO;
using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Game", menuName = "Data/Game")]
    public sealed class GameData : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _levelDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _interactableDataPath;
        [SerializeField] private string _gameUIDataPath;
        private LevelData _levelData;
        private PlayerData _playerData;
        private InteractableData _interactableData;
        private UIData _uiData;

        private const string DATA_FOLDER = "Data/";

        #endregion


        #region Properties

        public LevelData Level
        {
            get
            {
                if (_levelData == null)
                {
                    _levelData = Load<LevelData>(DATA_FOLDER + _levelDataPath);
                }

                return _levelData;
            }
        }

        public PlayerData Player
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Load<PlayerData>(DATA_FOLDER + _playerDataPath);
                }

                return _playerData;
            }
        }

        public InteractableData Interactable
        {
            get
            {
                if (_interactableData == null)
                {
                    _interactableData = Load<InteractableData>(DATA_FOLDER + _interactableDataPath);
                }

                return _interactableData;
            }
        }

        public UIData UI
        {
            get
            {
                if (_uiData == null)
                {
                    _uiData = Load<UIData>(DATA_FOLDER + _gameUIDataPath);
                }

                return _uiData;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

        #endregion
    }
}