namespace RollABall
{
    internal sealed class PlayerController
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeLCycles

        internal PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        #endregion
    }
}