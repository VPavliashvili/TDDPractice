using System;
using System.Collections.Generic;
using System.Text;

namespace Queue;

public class MyQueue<T>
{

    public bool IsEmpty => Count == 0;
    public int Count { get; private set; }
    public T Front => GetFrontAndCheckForEmptiness();

    private readonly IDequeueStrategy<T> _dequeueStrategy;
    private T[] _memory;
    private int _currentMaxSize = 16;

    public MyQueue()
    {
        _memory = new T[_currentMaxSize];
        _dequeueStrategy = new BasicDequeueStrategy<T>(this);
    }

    public void Enqueue(T newObject)
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

        _memory = new T[_currentMaxSize];
        for (int i = 0, length = temp.Length; i < length; i++)
        {
            _memory[i] = temp[i];
        }
    }

    public T Dequeue()
    {
        T dequeued = GetFrontAndCheckForEmptiness();
        Count--;
        _memory = _dequeueStrategy.GetModifiedMemory(_memory);

        return dequeued;
    }

    private T GetFrontAndCheckForEmptiness()
    {
        return !IsEmpty ? _memory[0] : throw new InvalidOperationException();
    }

}
