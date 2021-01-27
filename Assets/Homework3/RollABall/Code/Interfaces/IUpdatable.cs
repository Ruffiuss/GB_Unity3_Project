namespace RollABall
{
    internal interface IUpdatable : IControllable
    {
        #region Methods

        void UpdateTick(float deltaTime);

        #endregion
    }
}