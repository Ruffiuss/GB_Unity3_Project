namespace RollABall
{
    public interface IImprover : IInteractable
    {
        #region Feields

        event System.Action<UnityEngine.Collider, float> TriggerOnEnter;

        #endregion


        #region Methods

        void DefineProperty(float property);

        #endregion
    }
}