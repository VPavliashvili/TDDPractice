using System;

namespace MyStack
{

    public class FixedSizeStack : IStack
    {
        public int Count => _count;
        public object Peek => !IsEmpty() ? _elemens[curIndex] : throw new InvalidOperationException("Can't peek from empty stack");

        private int curIndex { get => !IsEmpty() ? _count - 1 : 0; }

        private int _count;
        private readonly int _capacity;

        private readonly object[] _elemens;

        public FixedSizeStack(int capacity)
        {
            _capacity = capacity;
            _elemens = new object[capacity];
        }

        public void Push(object value)
        {

            if (IsFull())
                throw new InvalidOperationException("Already reached stack capacity, can't push anymore values");

            _count++;
            _elemens[curIndex] = value;
        }

        public object Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Can't pop from empty stack");

            object res = Peek;
            _count--;
            return res;
        }

        public bool IsFull()
        {
            return _count == _capacity;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

    }

}