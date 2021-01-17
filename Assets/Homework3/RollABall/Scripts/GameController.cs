using UnityEngine;
using System.Collections.Generic;


namespace RollABall
{
    internal class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameData GameData;
        
        private List<IUpdatable> _iUpdatables = new List<IUpdatable>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            GameContext gameContext = new GameContext();
            new InitializeController(this, gameContext, GameData);
        }

        private void Update()
        {
            foreach (var item in _iUpdatables)
            {
                item.UpdateTick();
            }
        }

        #endregion


        #region Methods

        internal void AddIUpdatable(IUpdatable updatable)
        {
            _iUpdatables.Add(updatable);
        }

        internal void RemoveIUpdatable(IUpdatable updatable)
        {
            _iUpdatables.Remove(updatable);
        }

        #endregion
    }
}