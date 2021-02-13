using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableController : IUpdatable
    {
        #region Fields

        private List<IInteractable> _interactableViews = new List<IInteractable>();
        private List<GameObject> _subInteractableProviders = new List<GameObject>();
        private List<IImprovable> _improvableControllers = new List<IImprovable>();
        private List<IDegradable> _degradableControllers = new List<IDegradable>();
        private ISpeedImprover _improverListener;
        private ISpeedDegrader _degraderListener;
        private IScoreAdder _scoreListener;

        private float _pulsingValue = 2.1f;
        private float _pulsingMin = 2.0f;
        private float _pulsingMax = 4.0f;
        private bool _isGrow = true;
        private const float SMOOTH = 0.03f;

        #endregion


        #region ClassLifeCycles

        internal InteractableController(List<GameObject> providers, List<IUpgradable> upgradables)
        {
            _subInteractableProviders = providers;
            DefineSubcontrollers(upgradables);
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltaTime)
        {
            foreach (var item in _subInteractableProviders)
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
            _interactableViews.Add(view);

            if (view is ISpeedImprover improver)
            {
                _improverListener = improver;
                _improverListener.SpeedImprove += ChangeSpeed;
                _improverListener.DestroyProvider += UnsubsribeView;
            }
            if (view is ISpeedDegrader degrader)
            {
                _degraderListener = degrader;
                _degraderListener.SpeedDegrade += ChangeSpeed;
                _degraderListener.DestroyProvider += UnsubsribeView;
            }
            if (view is IScoreAdder adder)
            {
                _scoreListener = adder;
                _scoreListener.AddScore += ChangeScore;
                _scoreListener.DestroyProvider += UnsubsribeView;
            }
        }

        internal void UnsubsribeView(GameObject provider)
        {
            var component = provider.GetComponent<IInteractable>();

            if (component is ISpeedImprover improver)
            {
                improver.SpeedImprove -= ChangeSpeed;
                improver.DestroyProvider -= UnsubsribeView;
                _interactableViews.Remove(improver);
                _subInteractableProviders.Remove(provider);
            }
            if (component is ISpeedDegrader degrader)
            {
                degrader.SpeedDegrade -= ChangeSpeed;
                degrader.DestroyProvider -= UnsubsribeView;
                _interactableViews.Remove(degrader);
                _subInteractableProviders.Remove(provider);
            }
            if (component is IScoreAdder adder)
            {
                adder.AddScore -= ChangeScore;
                adder.DestroyProvider -= UnsubsribeView;
            }
        }

        private void ChangeSpeed(Collider obj, float property)
        {
            switch (obj.tag)
            {
                case "Player":
                    foreach (var improvable in _improvableControllers)
                    {
                        improvable.ImproveSpeed(property);
                    }                    
                    break;
                default:
                    break;
            }
        }

        private void ChangeScore(int scorePoints)
        {
            foreach (var improvable in _improvableControllers)
            {
                improvable.ImproveScore(scorePoints);
            }
        }


        private void DefineSubcontrollers<T>(List<T> controllers) where T : IUpgradable
        {
            foreach(var controller in controllers)
            {
                switch(controller)
                {
                    case IImprovable improvable:
                        _improvableControllers.Add(improvable);
                        break;
                    case IDegradable degradable:
                        _degradableControllers.Add(degradable);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}