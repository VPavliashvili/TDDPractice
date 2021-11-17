using MyStack;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class StackTests
{
    private readonly IStackFactory _factory;
    private readonly ITestOutputHelper _output;

    public StackTests(ITestOutputHelper output)
    {
        _factory = new StackFactory();
        _output = output;
    }

    [Fact]
    public void ShouldDetectWhenFullWithCapacity()
    {
        IStack stack = _factory.CreateFullStack();

        bool isFull = stack.IsFull();

        Assert.True(isFull);
    }

    [Fact]
    public void ShouldDetectWhenNotFullWichoutCapacity()
    {
        IStack stack = _factory.CreateStack();

        bool isFull = stack.IsFull();

        Assert.False(isFull);
    }

    [Fact]
    public void ShouldDetectWhenNotFullAndHasCapacity()
    {
        IStack stack = _factory.CreateStack(3);
        stack.Push(1);
        stack.Push(2);

        bool isFull = stack.IsFull();

        Assert.False(isFull);
    }

    [Fact]
    public void ShouldPushElement()
    {
        //arrange
        IStack stack = _factory.CreateStack();
        int before = stack.Count;
        object valToPush = 10;

        //act
        stack.Push(valToPush);
        int after = stack.Count;
        object peek = stack.Peek;

        //assert
        Assert.True(before < after && peek == valToPush);

    }

    [Fact]
    public void ShouldThrowStackOverlfowExceptionWhenPushingIntoFullStack()
    {
        IStack stack = _factory.CreateStack(1);
        object valToPush = 10;
        stack.Push(valToPush);

        Assert.Throws<StackOverflowException>(() => stack.Push(valToPush));
    }

    [Fact]
    public void ShouldGetPeekElement()
    {
        IStack stack = _factory.CreateStack();
        object valToAdd = 7;
        stack.Push(valToAdd);

        var element = stack.Peek;

        Assert.Equal(valToAdd, element);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPeekingFromEmptyStack()
    {
        IStack stack = _factory.CreateEmptyStack();

        Assert.Throws<InvalidOperationException>(() => stack.Peek);
    }

    [Fact]
    public void ShouldDetectWhenEmpty()
    {
        IStack stack = _factory.CreateEmptyStack();

        bool isEmpty = stack.IsEmpty();

        Assert.True(isEmpty);
    }

    [Fact]
    public void ShouldDetectWhenNotEmpty()
    {
        IStack stack = _factory.CreatePopulatedStack();
        stack.Push(12);

        bool isEmpty = stack.IsEmpty();

        Assert.False(isEmpty);
    }

    [Fact]
    public void ShouldPopWhenNotEmpty()
    {
        IStack stack = _factory.CreateStack();
        object valToPush = 19;
        stack.Push(valToPush);

        object o = default;
        Assert.Null(Record.Exception(() => o = stack.Pop()));

        Assert.NotNull(o);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPopingFromEmptyStack()
    {
        IStack stack = _factory.CreateEmptyStack();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void ShouldRemovePoppedValueFromStack()
    {
        IStack stack = _factory.CreateStack();
        object toPopped = 10;
        object expectedPeek = 15;
        stack.Push(expectedPeek);
        stack.Push(toPopped);

        stack.Pop();
        object newPeek = stack.Peek;

        Assert.NotEqual(toPopped, newPeek);
        Assert.Equal(expectedPeek, newPeek);
    }

    [Fact]
    public void ShuldDecreaseCountAfterPop()
    {
        IStack stack = _factory.CreateStack();
        object val1 = 1;
        object val2 = 1;
        object val3 = 1;
        object val4 = 1;
        stack.Push(val1);
        stack.Push(val2);
        stack.Push(val3);
        stack.Push(val4);
        int countBefore = stack.Count;


        stack.Pop();
        stack.Pop();
        int countAfter = stack.Count;

        Assert.True(countBefore > countAfter);
    }

    [Fact]
    public void ShouldRememberAllStoredElements()
    {
        IStack stack = _factory.CreateStack();
        object value5 = 5;
        object value4 = 4;
        object value3 = 3;
        object value2 = 2;
        object value = 1;
        stack.Push(value);
        stack.Push(value2);
        stack.Push(value3);
        stack.Push(value4);
        stack.Push(value5);

        object[] arr = new object[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = stack.Pop();
            _output.WriteLine($"index: {i} -> {arr[i]}");
        }

        Assert.Equal(value5, arr[0]);
        Assert.Equal(value4, arr[1]);
        Assert.Equal(value3, arr[2]);
        Assert.Equal(value2, arr[3]);
        Assert.Equal(value, arr[4]);
    }

}
