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
        myQueue.Enqueue(default);
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
    public void ShouldIncreaseCountAfterEnqueuing()
    {
        MyQueue myQueue = new();
        int before = myQueue.Count;
        myQueue.Enqueue(default);
        int after = myQueue.Count;

        Assert.True(before < after);
    }

    [Theory]
    [InlineData(1)]
    public void ShouldRememberEnquedElementAsFront(object parameter)
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(parameter);

        object front = myQueue.Front;

        Assert.Equal(parameter, front);
    }

    [Fact]
    public void ShouldKeepUpRightFrontMemory()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);

        object front = myQueue.Front;

        Assert.Equal(1, front);
    }

    [Fact]
    public void ShouldKeepUpRightCounting()
    {
        object[] vals = { 1, 2, 3 };
        MyQueue myQueue = new();
        foreach (object elem in vals)
        {
            myQueue.Enqueue(elem);
        }
        
        int count = myQueue.Count;

        Assert.Equal(vals.Length, count);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenDequeuingEmptyQueue()
    {
        MyQueue myQueue = new();

        Assert.Throws<InvalidOperationException>(() => myQueue.Dequeue());
    }

    [Fact]
    public void ShouldNotThrowInvalidOperationExceptionWhenDequeuingAndNotEmpty()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(default);

        var exception = Record.Exception(() => myQueue.Dequeue());

        Assert.Null(exception);
    }

    [Fact]
    public void ShouldDecreaseCountAfterDequeue()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);

        int before = myQueue.Count;

        myQueue.Dequeue();
        int after = myQueue.Count;

        Assert.True(before > after);
    }

    [Fact]
    public void ShouldChangeFrontAfterDequeue()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);

        myQueue.Dequeue();
        myQueue.Dequeue();

        object front = myQueue.Front;

        Assert.Equal(3, front);
    }

    [Fact]
    public void ShouldReturnFrontObjectWhenDequeueing()
    {
        MyQueue myQueue = new();
        myQueue.Enqueue(1);

        object front = myQueue.Front;
        object dequeued = myQueue.Dequeue();

        Assert.Equal(front, dequeued);
    }

    [Fact]
    public void ShouldRememberAllContainingElements()
    {
        object[] vals = { 1, "23", 'a', true };

        MyQueue myQueue = new();
        foreach (object val in vals)
        {
            myQueue.Enqueue(val);
        }

        for (int i = 0, len = myQueue.Count; i < len; i++)
        {
            object dequeued = myQueue.Dequeue();
            object expected = vals[i];

            Assert.Equal(expected, dequeued);
        }

    }

}