using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace RollABall
{
    internal sealed class BinarySerializationData<T> : ISaver<T>
    {
        #region Fields

        private static BinaryFormatter _formatter;

        #endregion


        #region ClassLifeCycles

        internal BinarySerializationData()
        {
            _formatter = new BinaryFormatter();
        }

        #endregion


        #region Methods

        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("No data to load. Path doesen`t exist!");
            }
            if (!typeof(T).IsSerializable)
            {
                throw new InvalidOperationException("This type doesen`t serializable!");
            }
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
