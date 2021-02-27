using System.IO;
using UnityEngine;

namespace RollABall
{
    internal sealed class SaveDataRepository
    {
        #region Fields

        private readonly ISaver<SavedData> _data;
        private readonly string _path;

        #endregion


        #region ClassLifeCycles

        internal SaveDataRepository()
        {
            CheckPlatform(Application.platform, ref _data);

            _path = Path.Combine(Application.dataPath, GlobalProperties.SAVES_FOLDER_NAME);
        }

        #endregion


        #region Methods

        private void CheckPlatform(RuntimePlatform platform, ref ISaver<SavedData> data)
        {
            if (platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new PlayerPrefsData();
            }
            else
            {
                data = new JsonData<SavedData>();
            }
        }

        internal void Save(PlayerController controller)
        {
            if (Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Name = "Arseny",
                PlayerPosition = controller.Rigidbody.transform.position,//Vector3.zero,//player.transform.position,
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, GlobalProperties.SAVES_FILE_NAME));
        }

        internal void Load(PlayerController controller)
        {
            var file = Path.Combine(_path, GlobalProperties.SAVES_FILE_NAME);
            if (!File.Exists(file)) return;

            var newPlayer = _data.Load(file);
            controller.Rigidbody.transform.position = newPlayer.PlayerPosition;
            //player.name = newPlayer.Name;
            //player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer.PlayerPosition);
        }

        #endregion
    }
}