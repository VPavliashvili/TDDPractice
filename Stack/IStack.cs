namespace MyStack
{

    public interface IStack
    {
        int Count { get; }
        object Peek { get; }

        bool IsFull();
        bool IsEmpty();
        void Push(object value);
        object Pop();
    }
}