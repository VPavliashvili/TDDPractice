using System.Collections.Generic;

//using Queue;

//MyQueue queue = new();
//queue.Enqueue();

Console.WriteLine();

Stack<int> stack = new();
stack.Push(1);
stack.Pop();

Queue<int> q = new();
q.Enqueue(1);
q.Dequeue();

ArrayOwner ao = new();
ao.PrintArray();
Console.WriteLine("modifying...");
ao.ModifyArr();
ao.PrintArray();

class ArrayOwner
{
    private int[] _array = new int[5];
    private readonly ArrStrategy _strategy;

    public ArrayOwner()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = i + 1;
        }

        _strategy = new ArrStrategy(_array);
    }

    public void ModifyArr()
    {
        _array = _strategy.ModifyArray();
    }

    public void PrintArray()
    {
        foreach (int elem in _array)
        {
            Console.Write(elem + " ");
        }
        Console.WriteLine();
    }

}

class ArrStrategy
{
    private int[] _arr;

    public ArrStrategy(int[] arr)
    {
        _arr = arr;
    }

    public int[] ModifyArray()
    {
        _arr = new int[] { 1, 2, 3 };
        return _arr;
    }
}