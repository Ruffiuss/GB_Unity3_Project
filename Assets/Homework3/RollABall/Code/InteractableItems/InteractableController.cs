using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableController : IUpdatable
    {
        #region Fields

        private InteractableModel _interactableModel;

        private List<IInteractable> _interactableViews = new List<IInteractable>();
        private List<IUpgradable> _upgradableControllers = new List<IUpgradable>();
        private ISpeedChanger _speedChange;
        private IScoreChanger _scoreChange;

        private float _pulsingValue = 2.1f;
        private float _pulsingMin = 2.0f;
        private float _pulsingMax = 4.0f;
        private bool _isGrow = true;
        private const float SMOOTH = 0.03f;

        #endregion


        #region ClassLifeCycles

        internal InteractableController(InteractableModel model)
        {
            _interactableModel = model;
            DefineSubcontrollers(_interactableModel.Upgradables);
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltaTime)
        {
            foreach (var item in _interactableModel.Providers)
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

            if (view is ISpeedChanger improver)
            {
                _speedChange = improver;
                _speedChange.SpeedChange += ChangeSpeed;
                _speedChange.DestroyProvider += UnsubsribeView;
            }
            if (view is IScoreChanger adder)
            {
                _scoreChange = adder;
                _scoreChange.AddScore += ChangeScore;
                _scoreChange.DestroyProvider += UnsubsribeView;
            }
        }

        internal void UnsubsribeView(GameObject provider)
        {
            var component = provider.GetComponent<IInteractable>();

            if (component is ISpeedChanger improver)
            {
                improver.SpeedChange -= ChangeSpeed;
                improver.DestroyProvider -= UnsubsribeView;
                _interactableViews.Remove(improver);
                _interactableModel.Providers.Remove(provider);
            }
            if (component is IScoreChanger adder)
            {
                adder.AddScore -= ChangeScore;
                adder.DestroyProvider -= UnsubsribeView;
            }
        }

        private void ChangeSpeed(Collider obj, IInteractable caller)
        {
            switch (obj.tag)
            {
                case "Player":
                    foreach (var improvable in _upgradableControllers)
                    {
                        improvable.ChangeSpeed(_interactableModel.GetProperty(caller, 0));
                    }                    
                    break;
                default:
                    break;
            }
        }

        private void ChangeScore(bool isTrigger, IInteractable caller)
        {
            if (isTrigger)
            {
                _interactableModel.GameProcess.ChangeScore((int)_interactableModel.GetProperty(caller, 1));
            }
        }

        private void DefineSubcontrollers<T>(List<T> controllers) where T : IUpgradable
        {
            foreach(var controller in controllers)
            {
                _upgradableControllers.Add(controller);
            }
        }

        #endregion
    }
}