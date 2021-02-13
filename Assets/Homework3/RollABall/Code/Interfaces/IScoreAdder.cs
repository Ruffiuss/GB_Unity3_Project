namespace RollABall
{
    public interface IScoreAdder : IInteractable
    {
        event System.Action<int> AddScore;
        void DefineScoreProperty(int scoreProp);
    }
}