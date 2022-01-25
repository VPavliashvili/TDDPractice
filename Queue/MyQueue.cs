using System;
using System.Collections.Generic;
using System.Text;

namespace Queue;

public class MyQueue
{

    public bool IsEmpty => _count == 0;

    public object Front => !IsEmpty ? 1 : throw new InvalidOperationException();

    private int _count;

    public void IncreaseCount() => _count++;

    public void Enqueue() => throw new NotImplementedException();
}
