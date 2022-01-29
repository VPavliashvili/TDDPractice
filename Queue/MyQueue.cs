using System;
using System.Collections.Generic;
using System.Text;

namespace Queue;

public class MyQueue
{

    public bool IsEmpty => Count == 0;
    public int Count { get; private set; }
    public object Front => GetFrontAndCheckForEmptiness();

    private readonly IDequeueStrategy _dequeueStrategy;
    private object[] _memory;

    public MyQueue()
    {
        _memory = new object[16];
        _dequeueStrategy = new BasicDequeueStrategy(this);
    }

    public void Enqueue(object newObject)
    {
        _memory[Count] = newObject;
        Count++;
    }

    public object Dequeue()
    {
        object dequeued = GetFrontAndCheckForEmptiness();
        Count--;
        _memory = _dequeueStrategy.GetModifiedMemory(_memory);

        return dequeued;
    }

    private object GetFrontAndCheckForEmptiness()
    {
        return !IsEmpty ? _memory[0] : throw new InvalidOperationException();
    }

}
