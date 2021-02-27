using System;
using UnityEngine;


namespace RollABall
{
    [Serializable]
    internal sealed class SavedData
    {
        #region Feilds

        public Vector3Serializable PlayerPosition;
        public string Name;
        public bool IsEnabled;

        #endregion


        #region Methods



        #endregion
    }

    [Serializable]
    public struct Vector3Serializable
    {
        internal float _x;
        internal float _y;
        internal float _z;

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            _x = valueX;
            _y = valueY;
            _z = valueZ;
        }

        #region Extensions

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value._x, value._y, value._z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $"(X = {_x} Y = {_y} Z = {_z})";

        #endregion
    }
}