using System;


namespace RollABall
{
    public interface IImprover : IInteractable
    {
        #region Feields

        event Action<float> SpeedImprover;

        #endregion
    }
}