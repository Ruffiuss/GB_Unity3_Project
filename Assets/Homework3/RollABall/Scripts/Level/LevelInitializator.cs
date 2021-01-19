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
            levelStruct.PlayerSpawn = spawnedLevel.transform.GetChild(0).transform.position;

            var levelModel = new LevelModel(levelStruct);

            new LevelController(levelModel);

            gameContext.SetPlayerSpawn(levelStruct.PlayerSpawn);
        }

        #endregion
    }
}