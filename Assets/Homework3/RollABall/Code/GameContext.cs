// delete
// using System.Collections.Generic;
// using UnityEngine;


// namespace RollABall
// {
//     internal class GameContext
//     {
//         #region Fields

//         private List<IControllable> _iControllers = new List<IControllable>();
//         private List<Vector3> _interactableSpawns;
//         private Vector3 _playerSpawn = Vector3.zero;

//         #endregion


//         #region Properties

//         internal Vector3 PlayerSpawn
//         {
//             get
//             {
//                 return _playerSpawn;
//             }
//             private set 
//             {
//                 _playerSpawn = value;
//             }
//         }

//         internal List<Vector3> InteractableSpawns
//         {
//             get
//             {
//                 return _interactableSpawns;
//             }
//         }

//         #endregion


//         #region Methods

//         internal void SetPlayerSpawn(Vector3 spawnPosition)
//         {
//             PlayerSpawn = spawnPosition;
//         }

//         internal void SetInteractableSpawns(Vector3[] interactableSpawns)
//         {
//             _interactableSpawns = new List<Vector3>();
//             for (int i = 0; i < interactableSpawns.Length; i++)
//             {
//                 _interactableSpawns.Add(interactableSpawns[i]);
//             }
//         }

//         internal void AddController<T>(T controller) where T : IControllable
//         {
//             _iControllers.Add(controller);
//         }

//         internal void RemoveController<T>(T controller) where T : IControllable
//         {
//             _iControllers.Remove(controller);
//         }

//         internal List<IControllable> GetControllers()
//         {
//             return _iControllers;
//         }

//         #endregion
//     }
// }