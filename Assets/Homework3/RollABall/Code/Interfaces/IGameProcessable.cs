namespace RollABall
{
    public interface IGameProcessable : IControllable
    {
        event System.Action<int> GameEnded;
        void ChangeScore(int scorePoints);
    }
}