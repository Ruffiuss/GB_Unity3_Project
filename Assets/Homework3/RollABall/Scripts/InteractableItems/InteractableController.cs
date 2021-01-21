using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableController : IControllable, IUpdatable
    {
        #region Fields

        private InteractableModel _interactableModel;

        private float _pulsingValue = 2.1f;
        private float _pulsingMin = 2.0f;
        private float _pulsingMax = 4.0f;
        private const float SMOOTH = 0.03f;
        private bool _isGrow = true;

        #endregion


        #region ClassLifeCycles

        internal InteractableController(InteractableModel interactableModel)
        {
            _interactableModel = interactableModel;
        }

        #endregion


        #region Methods

        public void UpdateTick()
        {

            foreach (var item in _interactableModel._interactableStruct.SpawnedInteractable)
            {
                _pulsingValue = item.transform.localScale.x;
                if (_isGrow)
                {
                    _pulsingValue = Mathf.Lerp(_pulsingValue, _pulsingMax, SMOOTH);
                    item.transform.localScale = new Vector3(_pulsingValue, _pulsingValue, _pulsingValue);

                    if (_pulsingValue > 3.98f)
                    {
                        _isGrow = !_isGrow;
                    }
                }
                else
                {
                    _pulsingValue = Mathf.Lerp(_pulsingValue, _pulsingMin, SMOOTH);
                    item.transform.localScale = new Vector3(_pulsingValue, _pulsingValue, _pulsingValue);

                    if (_pulsingValue < 2.02f)
                    {
                        _isGrow = !_isGrow;
                    }
                }
            }
        }

        #endregion
    }
}