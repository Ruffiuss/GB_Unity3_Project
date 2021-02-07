namespace RollABall
{
    internal interface IDegrader : IInteractable
    {
        #region Feields

        event System.Action<UnityEngine.Collider, float> TriggerOnEnter;

        #endregion


        #region Methods

        void DefineProperty(float property);

        #endregion
    }
}