using MyStack;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class FixedSizeStackTests
{
    private readonly ITestOutputHelper _output;

    public FixedSizeStackTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void ShouldDetectWhenFull()
    {
        IStack stack = FixedSizeStackHelper.CreateFullStack();

        bool isFull = stack.IsFull();

        Assert.True(isFull);
    }

    [Fact]
    public void ShouldDetectWhenNotFull()
    {
        IStack stack = new FixedSizeStack(3);
        stack.Push(1);
        stack.Push(2);

        bool isFull = stack.IsFull();

        Assert.False(isFull);
    }

    [Fact]
    public void ShouldPushElement()
    {
        //arrange
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
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
    public void ShouldThrowInvalidOperationExceptionWhenPushingIntoFullStack()
    {
        IStack stack = new FixedSizeStack(1);
        object valToPush = 10;
        stack.Push(valToPush);

        Assert.Throws<InvalidOperationException>(() => stack.Push(valToPush));
    }

    [Fact]
    public void ShouldGetPeekElement()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
        object valToAdd = 7;
        stack.Push(valToAdd);

        var element = stack.Peek;

        Assert.Equal(valToAdd, element);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPeekingFromEmptyStack()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();

        Assert.Throws<InvalidOperationException>(() => stack.Peek);
    }

    [Fact]
    public void ShouldDetectWhenEmpty()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();

        bool isEmpty = stack.IsEmpty();

        Assert.True(isEmpty);
    }

    [Fact]
    public void ShouldDetectWhenNotEmpty()
    {
        IStack stack = FixedSizeStackHelper.CreatePopulatedStack();
        stack.Push(12);

        bool isEmpty = stack.IsEmpty();

        Assert.False(isEmpty);
    }

    [Fact]
    public void ShouldPopWhenNotEmpty()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
        object valToPush = 19;
        stack.Push(valToPush);

        object o = default;
        Assert.Null(Record.Exception(() => o = stack.Pop()));

        Assert.NotNull(o);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPopingFromEmptyStack()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void ShouldRemovePoppedValueFromStack()
    {
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
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
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
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
        IStack stack = FixedSizeStackHelper.CreateEmptyStack();
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
