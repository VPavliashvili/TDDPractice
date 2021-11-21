using MyStack;

namespace Tests;

internal static class FixedSizeStackHelper
{
    public static IStack<T> CreateEmptyStack<T>()
    {
        return new MyStack<T>(10);
    }

    public static IStack<object> CreatePopulatedStack()
    {
        IStack<object> stack = CreateEmptyStack<object>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        return stack;
    }

    public static IStack<object> CreateFullStack()
    {
        IStack<object> stack = new MyStack<object>(2);
        stack.Push(1);
        stack.Push(2);
        return stack;
    }

    public static IStack<T> CreateNonFullStack<T>()
    {
        return CreateEmptyStack<T>();
    }
}
