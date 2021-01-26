using UnityEngine;


namespace RollABall
{
    public interface ISubInteractable : IInteractable
    {
        GameObject SubInteractableGameObject { get; }
    }
}