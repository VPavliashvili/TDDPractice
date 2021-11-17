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

    public interface IStackFactory
    {
        IStack CreateStack();
        IStack CreateStack(int capacity);
    }

    public class StackFactory : IStackFactory
    {
        public IStack CreateStack() => new FixedSizeStack(byte.MaxValue);
        public IStack CreateStack(int n) => new FixedSizeStack(n);
    }
}