using System;

namespace MyStack
{

    public class MyStack<T> : IStack<T>
    {
        public int Count => _count;
        public T Peek
        {
            get
            {
                CheckForEmptyAndHandleException();
                return _elements[curIndex];
            }
        }

        private int curIndex { get => !IsEmpty() ? _count - 1 : 0; }

        private int _count;
        private int _capacity;

        private T[] _elements;

        public MyStack(int capacity)
        {
            _capacity = capacity;
            _elements = new T[capacity];
        }

        public void Push(T value)
        {

            if (IsFull())
            {
                ResizeContainerIfReachedCapacity();
            }

            _count++;
            _elements[curIndex] = value;
        }

        private void ResizeContainerIfReachedCapacity()
        {
            _capacity++;
            T[] temp = new T[_capacity];
            _elements.CopyTo(temp, 0);

            _elements = new T[_capacity];
            temp.CopyTo(_elements, 0);
        }

        public T Pop()
        {
            CheckForEmptyAndHandleException();

            T res = Peek;
            _count--;
            return res;
        }

        private void CheckForEmptyAndHandleException()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The stack is empty!");

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