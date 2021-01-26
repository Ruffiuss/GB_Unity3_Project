using UnityEngine;


namespace RollABall
{
    internal sealed class LevelInitializator
    {
        #region ClassLifeCycles

        internal LevelInitializator(GameController gameController, GameContext gameContext, LevelData levelData)
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
                        levelStruct.PlayerSpawn = gameObject.transform.position;
                        break;
                    case "Interactable":
                        levelStruct.InteractablePositions = new Vector3[gameObject.transform.childCount];
                        for (int i2 = 0; i2 < gameObject.transform.childCount; i2++)
                        {
                            levelStruct.InteractablePositions[i2] = gameObject.transform.GetChild(i2).transform.position;
                        }
                        break;
                    default:
                        break;
                }
            }            

            var levelModel = new LevelModel(levelStruct);

            new LevelController(levelModel);

            gameContext.SetPlayerSpawn(levelStruct.PlayerSpawn);
            gameContext.SetInteractableSpawns(levelStruct.InteractablePositions);
        }

        #endregion
    }
}