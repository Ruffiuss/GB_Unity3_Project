namespace RollABall
{
    internal sealed class SaveController
    {
        #region Fields

        private readonly SaveDataRepository _saveDataRepository;
        private readonly ISaveable<PlayerController> _playerController;

        #endregion


        #region ClassLifeCycles

        internal SaveController(IInputProxy input, ISaveable<PlayerController> controller)
        {
            _saveDataRepository = new SaveDataRepository();
            _playerController = controller;
            input.SavePlayerPosition += SavePlayerPosition;
            input.LoadPlayerPosition += LoadPlayerPosition;            
        }

        #endregion


        #region Methods

        private void SavePlayerPosition(bool state)
        {
            if (state)
            {
                _saveDataRepository.Save(_playerController.Controller);
            }
        }

        private void LoadPlayerPosition(bool state)
        {
            if (state)
            {
                _saveDataRepository.Load(_playerController.Controller);
            }
        }

        #endregion
    }
}