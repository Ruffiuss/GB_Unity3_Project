namespace RollABall
{
    public interface IImprovable : IUpgradable
    {
        void ImproveSpeed(float value);
        void ImproveScore(int value);
    }
}