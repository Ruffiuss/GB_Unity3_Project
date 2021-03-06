﻿using System.IO;
using UnityEngine;


namespace RollABall
{
    internal sealed class JsonData<T> : ISaver<T>
    {
        #region Methods

        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);
        }

        #endregion
    }
}