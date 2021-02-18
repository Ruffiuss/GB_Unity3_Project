namespace RollABall
{
    internal sealed class InputController : IUpdatable
    {
        #region Fields

        private readonly IInputProxy _input;

        #endregion


        #region ClassLifeCycles

        public InputController(IInputProxy input)
        {
            _input = input;
        }

        #endregion


        #region Methods

        public void UpdateTick(float deltTime)
        {
            _input.GetAxisChanged();
            _input.GetKeyPressed();
        }

        #endregion
    }
}