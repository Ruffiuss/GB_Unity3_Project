using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Debug;


namespace RollABall
{
    internal class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameData GameData;
        
        private List<IUpdatable> _iUpdatables = new List<IUpdatable>();
        private List<IFixedUpdatable> _iFixedUpdatables = new List<IFixedUpdatable>();

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
        private void FixedUpdate()
        {
            foreach (var item in _iFixedUpdatables)
            {
                item.FixedUpdateTick();
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

        internal void AddIFixedUpdatable(IFixedUpdatable updatable)
        {
            _iFixedUpdatables.Add(updatable);
        }

        internal void RemoveIFixedUpdatable(IFixedUpdatable updatable)
        {
            _iFixedUpdatables.Remove(updatable);
        }

        #endregion
    }
}