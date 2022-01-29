namespace Queue;

internal class BasicDequeueStrategy : IDequeueStrategy
{
    private readonly MyQueue _myQueue;

    public BasicDequeueStrategy(MyQueue myQueue)
    {
        _myQueue = myQueue;
    }

    public object[] GetModifiedMemory(object[] memory)
    {
        object[] temp = new object[memory.Length];
        for (int i = 1; i <= _myQueue.Count; i++)
        {
            temp[i - 1] = memory[i];
        }
        memory = temp;
        return memory;
    }
}
