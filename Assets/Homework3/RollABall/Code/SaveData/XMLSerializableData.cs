﻿using System;
using System.IO;
using System.Xml.Serialization;


namespace RollABall
{
    internal sealed class XMLSerializableData<T> : ISaver<T>
    {
        #region Fields

        private static XmlSerializer _formatter;

        #endregion


        #region ClassLifeCycle

        internal XMLSerializableData()
        {
            _formatter = new XmlSerializer(typeof(T));
        }

        #endregion


        #region Methods

        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }
        }

        public T Load(string path = null)
        {
            T result;
            if (!File.Exists(path)) return default(T);

            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)_formatter.Deserialize(fs);
            }
            return result;
        }

        #endregion
    }
}