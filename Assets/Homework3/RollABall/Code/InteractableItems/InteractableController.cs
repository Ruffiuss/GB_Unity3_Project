using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableController : IUpdatable
    {
        #region Fields

        private InteractableData _interactableData;
        private List<IInteractable> _improverViews = new List<IInteractable>();
        private IImprover _improverListener;
        private IImprovable _improvableListener;

        private float _pulsingValue = 2.1f;
        private float _pulsingMin = 2.0f;
        private float _pulsingMax = 4.0f;
        private bool _isGrow = true;
        private const float SMOOTH = 0.03f;

        #endregion


        #region ClassLifeCycles

        internal InteractableController(InteractableData interactableData)
        {
            _interactableData = interactableData;
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltaTime)
        {
            foreach (var item in _interactableData.SpawnedInteractable)
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

        internal void SubsrcibeView(IInteractable view)
        {
            _improverViews.Add(view);
            if (view is IImprover)
            {
                _improverListener = (IImprover)view;
                _improverListener.TriggerOnEnter += ImproveTriggerEnter;
            }
        }

        private void ImproveTriggerEnter(Collider obj)
        {
            switch (obj.tag)
            {
                case "Player":
                    foreach (var upgradable in _interactableData.UpgradableControllers)
                    {
                        if (upgradable is IImprovable)
                        {
                            var target = (IImprovable)upgradable;
                            target.ImproveSpeed(20.0f);
                        }
                    }                    
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}