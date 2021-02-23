namespace RollABall
{
    public interface IScoreChanger : IInteractableView, IInteractable
    {
        event System.Action<bool, IInteractable> AddScore;
    }
}