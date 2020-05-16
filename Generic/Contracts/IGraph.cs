namespace Algorithms.Generic.Contracts{
    public interface IGraph<T>
    {
        int EdgeCount { get; }
        void Add(T v, T w);
        int Degree(T v);
        void Print();
    }
}