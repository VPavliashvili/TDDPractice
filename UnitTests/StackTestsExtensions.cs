using MyStack;

namespace Tests;

internal static class StackTestsExtensions
{
    public static IStack CreateEmptyStack(this IStackFactory factory)
    {
        return factory.CreateStack();
    }

    public static IStack CreatePopulatedStack(this IStackFactory factory)
    {
        IStack stack = factory.CreateStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        return stack;
    }

    public static IStack CreateFullStack(this IStackFactory factory)
    {
        IStack stack = factory.CreateStack(2);
        stack.Push(1);
        stack.Push(2);
        return stack;
    }

    public static IStack CreateNonFullStack(this IStackFactory factory)
    {
        return CreateEmptyStack(factory);
    }
}
