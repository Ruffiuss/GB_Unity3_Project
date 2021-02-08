using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableController : IUpdatable
    {
        #region Fields

        private List<IInteractable> _improverViews = new List<IInteractable>();
        private List<GameObject> _subInteractableProviders = new List<GameObject>();
        private List<IImprovable> _improvableControllers = new List<IImprovable>();
        private List<IDegradable> _degradableControllers = new List<IDegradable>();
        private IImprover _improverListener;
        private IDegrader _degraderListener;

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
            _improverViews.Add(view);
            switch (view)
            {
                case IImprover improver:
                    _improverListener = improver;
                    _improverListener.TriggerOnEnter += ImproveTriggerEnter;
                    _improverListener.DestroyProvider += UnsubsribeView;
                    break;
                case IDegrader degrader:
                    _degraderListener = degrader;
                    _degraderListener.TriggerOnEnter += ImproveTriggerEnter;
                    _degraderListener.DestroyProvider += UnsubsribeView;
                    break;
                default:
                    break;
            }

        }

        internal void UnsubsribeView(GameObject provider)
        {
            switch (provider.GetComponent<IInteractable>())
            {
                case IImprover improver:
                    improver.TriggerOnEnter -= ImproveTriggerEnter;
                    improver.DestroyProvider -= UnsubsribeView;
                    _improverViews.Remove(improver);
                    _subInteractableProviders.Remove(provider);
                    break;
                case IDegrader degrader:
                    degrader.TriggerOnEnter -= ImproveTriggerEnter;
                    degrader.DestroyProvider -= UnsubsribeView;
                    _improverViews.Remove(degrader);
                    _subInteractableProviders.Remove(provider);
                    break;
                default:
                    break;
            }

        }

        private void ImproveTriggerEnter(Collider obj, float property)
        {
            switch (obj.tag)
            {
                case "Player":
                    foreach (var improvable in _improvableControllers)
                    {
                        var target = improvable;
                        target.ImproveSpeed(property);
                    }                    
                    break;
                default:
                    break;
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