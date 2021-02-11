using UnityEngine;


namespace RollABall
{
    interface IMovable
    {
        Rigidbody Rigidbody { get; }
        float Speed { get; }
    }
}