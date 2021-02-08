using System.Collections.Generic;


namespace RollABall
{
    internal sealed class Controllers : IUpdatable, IFixedUpdatable, IInitialization, ICleanupable
    {
        #region Fields

        private readonly List<IInitialization> _initializeControllers;
        private readonly List<ICleanupable> _cleanupControllers;
        private readonly List<IUpgradable> _upgradableControllers;
        private readonly List<IUpdatable> _updatableControllers;
        private readonly List<IFixedUpdatable> _fixedUpdatableControllers;

        #endregion


        #region ClasslifeCycles

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _cleanupControllers = new List<ICleanupable>();
            _upgradableControllers = new List<IUpgradable>();
            _updatableControllers = new List<IUpdatable>();
            _fixedUpdatableControllers = new List<IFixedUpdatable>();
        }

        #endregion


        #region Methods

        internal Controllers Add(IControllable controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }
            if (controller is ICleanupable cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
            if (controller is IUpgradable upgradableController)
            {
                _upgradableControllers.Add(upgradableController);
            }
            if (controller is IUpdatable updatableController)
            {
                _updatableControllers.Add(updatableController);
            }
            if (controller is IFixedUpdatable fixedUpdatableController)
            {
                _fixedUpdatableControllers.Add(fixedUpdatableController);
            }

            return this;
        }

        public void Initialization()
        {
            for(var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }

        public void UpdateTick(float deltaTime)
        {
            for(var index = 0; index < _updatableControllers.Count; ++index)
            {
                _updatableControllers[index].UpdateTick(deltaTime);
            }
        }

        public void FixedUpdateTick(float fixedDeltaTime)
        {
            for(var index = 0; index < _fixedUpdatableControllers.Count; ++index)
            {
                _fixedUpdatableControllers[index].FixedUpdateTick(fixedDeltaTime);
            }
        }

        public List<IUpgradable> GetUpgradables()
        {
            return _upgradableControllers;
        }


        #endregion
    }
}