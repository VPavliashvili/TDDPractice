using MyStack;

namespace Tests;

internal static class FixedSizeStackHelper
{
    public static IStack CreateEmptyStack()
    {
        return new FixedSizeStack(10);
    }

    public static IStack CreatePopulatedStack()
    {
        IStack stack = CreateEmptyStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        return stack;
    }

    public static IStack CreateFullStack()
    {
        IStack stack = new FixedSizeStack(2);
        stack.Push(1);
        stack.Push(2);
        return stack;
    }

    public static IStack CreateNonFullStack()
    {
        return CreateEmptyStack();
    }
}
