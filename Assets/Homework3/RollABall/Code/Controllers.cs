using System.Collections.Generic;


namespace RollABall
{
    internal sealed class Controllers : IUpdatable, IFixedUpdatable, IInitialization//, ILateUpdatable, ICleanupable
    {
        #region Fields

        private readonly List<IInitialization> _initializeControllers;
        //private readonly List<ILateUpdatable> _lateControllers;
        //private readonly List<ICleanupable> _cleanupControllers;
        private readonly List<IUpgradable> _upgradableControllers;
        private readonly List<IUpdatable> _updatableControllers;
        private readonly List<IFixedUpdatable> _fixedUpdatableControllers;

        #endregion


        #region ClasslifeCycles

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            //_lateControllers = new List<ILateUpdatable>();
            //_cleanupControllers = new List<ICleanupable>();
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
            // if (controller is ILateUpdatable lateController)
            // {
            //     _lateControllers.Add(lateController);
            // }
            // if (controller is ICleanupable cleanupController)
            // {
            //     _cleanupControllers.Add(cleanupController);
            // }
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

        public void Initialization() //method of IInitialize interface
        {
            for(var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }

        //public void LateUpdateTick(float deltaTime) //method of ILateUpdateTick interface
        //{
        //    for(var index = 0; index < _lateControllers.Count; ++index)
        //    {
        //        _lateControllers[index].LateUpdateTick(deltaTime);
        //    }
        //}

        //public void Cleanup() //method of IClenup interface
        //{
        //    for(var index = 0; index < _cleanupControllers.Count; ++index)
        //    {
        //        _cleanupControllers[index].Cleanup();
        //    }
        //}

        public void UpdateTick(float deltaTime) //method of IUpdatable interface
        {
            for(var index = 0; index < _updatableControllers.Count; ++index)
            {
                _updatableControllers[index].UpdateTick(deltaTime);
            }
        }

        public void FixedUpdateTick(float deltaTime) //method of IFiexdUdpatable interface
        {
            for(var index = 0; index < _fixedUpdatableControllers.Count; ++index)
            {
                _fixedUpdatableControllers[index].FixedUpdateTick(deltaTime);
            }
        }

        public List<IUpgradable> GetUpgradables()
        {
            return _upgradableControllers;
        }


        #endregion
    }
}