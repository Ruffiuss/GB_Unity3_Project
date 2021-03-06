namespace RollABall
{
    public interface ISaver<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);
    }
}