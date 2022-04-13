namespace Queue;

internal class BasicDequeueStrategy<T> : IDequeueStrategy<T>
{
    private readonly MyQueue<T> _myQueue;

    public BasicDequeueStrategy(MyQueue<T> myQueue)
    {
        _myQueue = myQueue;
    }

    public T[] GetModifiedMemory(T[] memory)
    {
        T[] temp = new T[memory.Length];
        for (int i = 1; i <= _myQueue.Count; i++)
        {
            temp[i - 1] = memory[i];
        }
        memory = temp;
        return memory;
    }
}
