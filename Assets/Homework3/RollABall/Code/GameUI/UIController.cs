using UnityEngine;


namespace RollABall
{
    internal sealed class UIController : IUpdatable
    {
        #region Fields

        private GameObject _uiProvider;

        #endregion


        #region ClassLifeCycles

        public UIController(UIData uiData, GameObject uiProvider)
        {
            _uiProvider = uiProvider;
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltaTime)
        {
            
        }

        #endregion
    }
}
