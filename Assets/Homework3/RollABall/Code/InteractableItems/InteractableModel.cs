using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class InteractableModel
    {
        #region Properties

        public List<GameObject> Providers { get; }
        public List<IUpgradable> Upgradables { get; }
        public IGameProcessable GameProcess { get; }

        #endregion


        #region ClassLifeCycles

        internal InteractableModel(InteractableData data, IGameProcessable gameProcess)
        {
            Providers = new List<GameObject>();
            Upgradables = new List<IUpgradable>();
            GameProcess = gameProcess;
        }

        #endregion


        #region Methods

        internal void SubscribeEvent(InteractableInitializator interactableInitializator)
        {
            interactableInitializator.NewProvider += AddProvider;
        }

        internal void UnsubscribeEvent(InteractableInitializator interactableInitializator)
        {
            interactableInitializator.NewProvider -= AddProvider;
        }

        private void AddProvider(GameObject provider)
        {
            Providers.Add(provider);
        }

        internal void AddUpgradable(IUpgradable upgradable)
        {
            Upgradables.Add(upgradable);
        }

        #endregion
    }
}