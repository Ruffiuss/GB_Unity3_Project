using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableModel
    {
        #region Fields



        #endregion


        #region Properties

        public Dictionary<IInteractable, List<GameObject>> Interactables { get; }
        public List<GameObject> Providers { get; }
        public List<IUpgradable> Upgradables { get; }
        public Dictionary<IInteractable, List<float>> InteractableProperties { get; }
        public IGameProcessable GameProcess { get; }

        #endregion


        #region ClassLifeCycles

        internal InteractableModel(InteractableData data, IGameProcessable gameProcess)
        {
            Interactables = new Dictionary<IInteractable, List<GameObject>>();
            Providers = new List<GameObject>();
            Upgradables = new List<IUpgradable>();
            InteractableProperties = new Dictionary<IInteractable, List<float>>();
            GameProcess = gameProcess;
        }

        #endregion


        #region Methods

        internal void SubscribeEvent(InteractableInitializator interactableInitializator)
        {
            interactableInitializator.NewProvider += AddProvider;
            interactableInitializator.DefineProperty += AddDataProperty;
        }

        internal void UnsubscribeEvent(InteractableInitializator interactableInitializator)
        {
            interactableInitializator.NewProvider -= AddProvider;
        }

        private void AddProvider(GameObject provider)
        {
            Providers.Add(provider);

            var type = provider.GetComponent<IInteractable>();
            if (type is ISpeedChanger speedChanger)
            {
                AddInteractable(speedChanger, provider);
            }
            if (type is IScoreChanger scoreChanger)
            {
                AddInteractable(scoreChanger, provider);
            }
        }

        internal void AddUpgradable(IUpgradable upgradable)
        {
            Upgradables.Add(upgradable);
        }

        private void AddInteractable(IInteractable key, GameObject value)
        {            
            if (Interactables.ContainsKey(key))
            {
                Interactables[key].Add(value);
            }
            else
            {
                Interactables.Add(key, new List<GameObject>());
                Interactables[key].Add(value);
            }
        }

        internal void RemoveInteractableProvider(IInteractable key, GameObject value)
        {
            Interactables[key].Remove(value);
        }

        internal float GetProperty(IInteractable caller, int index)
        {
            return InteractableProperties[caller][index];
        }

        private void AddDataProperty(IInteractable interactable, float[] value)
        {
            if (interactable is ISpeedChanger speedChanger)
            {
                if (!InteractableProperties.ContainsKey(speedChanger))
                {
                    InteractableProperties.Add(speedChanger, new List<float>() { value[0] });
                }
                else
                {
                    InteractableProperties[speedChanger].Add(value[0]);
                }
            }
            if (interactable is IScoreChanger scoreChanger)
            {
                if (!InteractableProperties.ContainsKey(scoreChanger))
                {
                    InteractableProperties.Add(scoreChanger, new List<float>() { value[1] });
                }
                else
                {
                    InteractableProperties[scoreChanger].Add(value[1]);
                }
            }
        }

        #endregion
    }
}