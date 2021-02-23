namespace RollABall
{
    public interface ISpeedChanger : IInteractableView, IInteractable
    {
        event System.Action<UnityEngine.Collider, IInteractable> SpeedChange;
    }
}