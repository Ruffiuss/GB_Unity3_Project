namespace RollABall
{
    internal interface IImprover : IInteractable
    {
        #region Methods

        void Boost<T>(T improvable) where T : IImprovable;
        #endregion
    }
}