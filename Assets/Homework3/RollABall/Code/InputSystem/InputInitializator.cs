namespace RollABall
{
    internal sealed class InputInitializator
    {
        #region Fields

        private IInputProxy _pcInput;

        #endregion


        #region ClassLifeCycles

        public InputInitializator()
        {
            _pcInput = new PCInput();
        }

        #endregion


        #region Metgods

        public IInputProxy GetInput()
        {
            IInputProxy result = _pcInput;
            return result;
        }

        #endregion
    }
}