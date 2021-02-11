namespace RollABall
{
    internal sealed class InputController : IUpdatable
    {
        #region Fields

        private readonly IInputProxy _axises;

        #endregion


        #region ClassLifeCycles

        public InputController(IInputProxy input)
        {
            _axises = input;
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltTime)
        {
            _axises.GetAxis();
        }

        #endregion
    }
}