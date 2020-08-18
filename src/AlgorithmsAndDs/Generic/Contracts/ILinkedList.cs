namespace Algorithms.Generic.Contracts{
    public interface ILinkedList<T>
    {
        int Length { get; }
        void Add(T data);
    }
}