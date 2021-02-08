using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class LevelInitializator
    {
        #region Fields

        private readonly Transform _playerSpawn;
        private readonly List<Vector3> _interactableSpawns;
        private readonly GameObject _levelProvider;

        #endregion


        #region ClassLifeCycles

        internal LevelInitializator(LevelData levelData)
        {
            _levelProvider = Object.Instantiate(levelData.LevelProvider, Vector3.zero, Quaternion.identity);
            
            for (int i = 0; i < _levelProvider.transform.childCount; i++)
            {
                var gameObject = _levelProvider.transform.GetChild(i);
                switch (gameObject.tag)
                {
                    case "Respawn":
                        _playerSpawn = gameObject.transform;
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