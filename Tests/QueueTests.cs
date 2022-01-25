using Queue;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class QueueTests
{

    [Fact]
    public void ShouldDetectWhenEmpty()
    {
        MyQueue myQueue = new();
        bool isEmpty = myQueue.IsEmpty;

        Assert.True(isEmpty);
    }

    [Fact]
    public void ShouldDetectWhenNotEmpty()
    {
        MyQueue myQueue = new();
        myQueue.IncreaseCount();
        bool isEmpty = myQueue.IsEmpty;

        Assert.False(isEmpty);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenEmptyAndGettingFront()
    {
        MyQueue myQueue = new();
        
        Assert.Throws<InvalidOperationException>(() => myQueue.Front);
    }

    [Fact]
    public void ShouldNotThrowExceptionWhenNotEmptyAndGettingFront()
    {
        MyQueue myQueue = new();
        myQueue.IncreaseCount();

        var exception = Record.Exception(() => myQueue.Front);

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(1)]
    public void ShouldReturnProperValueWhenNotEmptyAndGettingFront(object parameter)
    {
        MyQueue myQueue = new();
        myQueue.IncreaseCount();

        object front = myQueue.Front;

        Assert.Equal(parameter, front);
    }

    [Fact]
    public void ShouldInsertNewValueInFrontWhenEnqueuing()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue();
    }

}