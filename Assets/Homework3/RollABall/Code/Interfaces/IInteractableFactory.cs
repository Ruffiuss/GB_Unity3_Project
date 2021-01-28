namespace RollABall
{
    public interface IInteractableFactory
    {
        IInteractable CreateSubInteractable(InteractableType type);
    }
}