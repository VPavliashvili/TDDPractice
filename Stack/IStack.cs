namespace MyStack
{

    public interface IStack<T>
    {
        int Count { get; }
        T Peek { get; }

        bool IsFull();
        bool IsEmpty();
        void Push(T value);
        T Pop();
    }
}