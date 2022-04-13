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
    private int _currentMaxSize = 16;

    public MyQueue()
    {
        _memory = new object[_currentMaxSize];
        _dequeueStrategy = new BasicDequeueStrategy(this);
    }

    public void Enqueue(object newObject)
    {
        _memory[Count] = newObject;
        Count++;

        if (Count == _currentMaxSize)
        {
            IncreaseFullMemory();
        }

    }

    private void IncreaseFullMemory()
    {
        _currentMaxSize *= 2;

        var temp = _memory;

        _memory = new object[_currentMaxSize];
        for (int i = 0, length = temp.Length; i < length; i++)
        {
            _memory[i] = temp[i];
        }
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
