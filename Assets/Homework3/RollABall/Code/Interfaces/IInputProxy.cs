using System;


namespace RollABall
{
    public interface IInputProxy
    {
        event Action<float, float> AxisOnChage;
        void GetAxis();
    }
}