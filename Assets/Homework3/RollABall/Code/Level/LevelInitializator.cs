using UnityEngine;


namespace RollABall
{
    internal sealed class LevelInitializator
    {
        //added
        #region Fields

        private readonly Transform _playerSpawn;
        private readonly List<Vector3> _interactableSpawns;

        #endregion
        //added

        #region ClassLifeCycles

        internal LevelInitializator(LevelData levelData) // changed
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
                        _playerSpawn = levelStruct.PlayerSpawn = gameObject.transform.position; //changed
                        break;
                    case "Interactable":
                        _interactableSpawns = new List<Vector3>(); //added
                        // levelStruct.InteractablePositions = new Vector3[gameObject.transform.childCount]; //delete
                        for (int i2 = 0; i2 < gameObject.transform.childCount; i2++)
                        {
                            // levelStruct.InteractablePositions[i2] = gameObject.transform.GetChild(i2).transform.position; // delete
                            _interactableSpawns.Add(gameObject.transform.GetChild(i2).transform.position); // added
                        }
                        break;
                    default:
                        break;
                }
            }            

            var levelModel = new LevelModel(levelStruct);

            new LevelController(levelModel);

            // gameContext.SetPlayerSpawn(levelStruct.PlayerSpawn); //delete
            // gameContext.SetInteractableSpawns(levelStruct.InteractablePositions); //delete
        }

        #endregion

        // added
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
        // added
    }
}