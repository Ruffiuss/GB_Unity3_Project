using System;
using UnityEngine;


namespace RollABall
{
    [Serializable]
    public sealed class SavedData
    {
        #region Feilds

        public Vector3Serializable PlayerPosition;
        public string Name;
        public bool IsEnabled;

        #endregion
    }

    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        #region Extensions

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $"(X = {X} Y = {Y} Z = {Z})";

        #endregion
    }
}