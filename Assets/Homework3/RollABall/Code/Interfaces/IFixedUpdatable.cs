namespace RollABall
{
    internal interface IFixedUpdatable : IControllable
    {
        void FixedUpdateTick(float deltaTime);
    }
}