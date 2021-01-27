using UnityEngine;


namespace RollABall
{
    internal sealed class LevelInitializator
    {
        #region Fields

        private readonly Transform _playerSpawn;
        private readonly List<Vector3> _interactableSpawns;

        #endregion


        #region ClassLifeCycles

        internal LevelInitializator(LevelData levelData)
        {
            var levelStruct = levelData.LevelStuct;

            var spawnedLevel = Object.Instantiate(levelStruct.LevelGameObject, Vector3.zero, Quaternion.identity);
            levelStruct.LevelGameObject = spawnedLevel;

            
            for (int i = 0; i < spawnedLevel.transform.childCount; i++)
            {
                var gameObject = spawnedLevel.transform.GetChild(i);
                switch (gameObject.tag)
                {
                    case "Respawn":
                        _playerSpawn = levelStruct.PlayerSpawn = gameObject.transform.position;
                        break;
                    case "Interactable":
                        _interactableSpawns = new List<Vector3>();
                        for (int i2 = 0; i2 < gameObject.transform.childCount; i2++)
                        {
                            _interactableSpawns.Add(gameObject.transform.GetChild(i2).transform.position);
                        }
                        break;
                    default:
                        break;
                }
            }            

            var levelModel = new LevelModel(levelStruct);
            new LevelController(levelModel);
        }

        #endregion


        #region Methods

        internal Transform GetPlayerSpawn()
        {
            return _playerSpawn;
        }

        internal List<Vector3> GetInteractableSpawns()
        {
            return _interactableSpawns;
        }

        #endregion
    }
}