namespace RollABall
{
    public interface ISpeedImprover : IInteractable
    {
        event System.Action<UnityEngine.Collider, float> SpeedImprove;
        void DefineSpeedProperty(float speedProp);
    }
}