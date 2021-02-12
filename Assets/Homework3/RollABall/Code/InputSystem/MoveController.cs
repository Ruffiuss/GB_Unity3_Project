using UnityEngine;


namespace RollABall
{
    internal sealed class MoveController : IFixedUpdatable, ICleanupable
    {
        #region Fields

        private readonly IMovable _unit;
        private IInputProxy _inputProxy;
        private Vector3 _movement;
        private float _inputHorizontal;
        private float _inputVertical;        

        #endregion


        #region ClassLifeCycles

        internal MoveController(IInputProxy input, IMovable unit)
        {
            _unit = unit;
            _inputProxy = input;
            _inputProxy.AxisOnChage += InputAxisOnChange;
        }

        #endregion

        #region Methods

        private void InputAxisOnChange(float horizontal, float vertical)
        {
            _inputHorizontal = horizontal;
            _inputVertical = vertical;
        }

        public void FixedUpdateTick(float fixedDeltaTime)
        {
            var speed = fixedDeltaTime * _unit.Speed;
            Debug.Log(_unit.Speed);
            _movement.Set(_inputHorizontal, 0.0f, _inputVertical);

            _unit.Rigidbody.AddForce(_movement * speed);
        }

        public void Cleanup()
        {
            _inputProxy.AxisOnChage -= InputAxisOnChange;
        }

        #endregion
    }
}