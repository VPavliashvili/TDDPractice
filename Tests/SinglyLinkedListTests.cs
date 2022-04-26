using LinkedList;
using System;
using System.Collections;
using Xunit;

namespace Tests;

public class SinglyLinkedListTests
{
    [Fact]
    public void GetHeadShouldReturnNullWhenEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();

        //act
        var head = sut.GetHead();

        //assert
        Assert.Null(head);
    }

    [Fact]
    public void GetHeadShouldNotReturnNullWhenNotEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);

        //act
        var head = sut.GetHead();

        //assert
        Assert.NotNull(head);
    }

    [Fact]
    public void CanMemorizeHeadValue_WhenPushing()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);

        //act
        var head = sut.GetHead();

        //assert
        Assert.Equal(1, head);
    }

    [Fact]
    public void PushedElementShouldBeHead()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);

        //act
        var head = sut.GetHead();

        //assert
        Assert.Equal(3, head);
    }

    
    [Fact]
    public void HeadValueShouldBeFirstAppendingElement_WhenEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(15);

        //act
        var head = sut.GetHead();

        //assert
        Assert.Equal(1, head);
    }

    [Fact]
    public void AppendedElemendShouldBeLast()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(5);
        sut.Append(10);

        //act
        var last = sut.GetLast();

        //assert
        Assert.Equal(10, last);
    }

    [Fact]
    public void GetLastShouldReturnNullIfEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();

        //act
        var last = sut.GetLast();

        //assert
        Assert.Null(last);
    }

    [Fact]
    public void HeadAndLastAreSameWhenAppendedOnEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(12);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //assert
        Assert.Equal(12, head);
        Assert.Equal(12, last);
        Assert.Equal(last, head);
    }

    [Fact]
    public void HeadAndLastAreSameWhenPushedOnEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //arrange
        Assert.Equal(1, head);
        Assert.Equal(1, last);
        Assert.Equal(last, head);
    }

    [Fact]
    public void HeadIsPushedAndLastIsAppendedWhenDoingBoth()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Append(7);
        sut.Push(10);
        sut.Append(5);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //assert
        Assert.Equal(10, head);
        Assert.Equal(5, last);
    }

    [Fact]
    public void FirstPushedIsLastAndLastPushedIsHead()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //arrange
        Assert.Equal(3, head);
        Assert.Equal(1, last);
    }

    [Fact]
    public void InsertAfterShoulThrowIndexOutOfRangeExceptionWhenInsertingInEmptyLinkedList()
    { 
        //arrange
        SinglyLinkedList sut = new();
        Action action = () => sut.InsertAfter(0, 1);

        //act
        var ex = Record.Exception(action);

        //assert
        Assert.IsType<IndexOutOfRangeException>(ex);
    }

    [Fact]
    public void InsertAfterShoulThrowIndexOutOfRangeExceptionWhenIndexIsBiggerThanLinkedListSize()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);

        Action action = () => sut.InsertAfter(index: 3, value: 10);

        //act
        var ex = Record.Exception(action);
        
        //assert
        Assert.IsType<IndexOutOfRangeException>(ex);

    }

    [Fact]
    public void InsertAfterShouldInsertObjectAsLastIfInsertionIndexIsLast()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Push(5);
        sut.Push(10);

        //act
        sut.InsertAfter(index: 2, value: 20);
        var last = sut.GetLast();

        //assert
        Assert.Equal(20, last);
    }

    [Fact]
    public void InsertAfterShouldInsertObjectBeforeLastIfIndexIsBeforeLast()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1); //index 2
        sut.Push(5); //index 1
        sut.Push(10); //index 0

        //act
        sut.InsertAfter(index: 1, value: 7);
        var last = sut.GetLast();
        var beforeLast = sut.ElementAt(2);

        //assert
        Assert.Equal(1, last);
        Assert.Equal(7, beforeLast);
    }

    [Fact]
    public void ElementAtShouldReturnIndexOutOfRangeExceptionWhenLinkedListIsEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        Action action = () => sut.ElementAt(0);

        //act
        var ex = Record.Exception(() => action());

        //assert
        Assert.IsType<IndexOutOfRangeException>(ex);
    }

    [Fact]
    public void ElementAtShouldReturnIndexOutOfRangeExceptionWhenIndexIsGreaterThanSizeOfLinkedList()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(1);
        sut.Push(2);
        Action action = () => sut.ElementAt(2);

        //act
        var ex = Record.Exception(() => action());

        //assert
        Assert.IsType<IndexOutOfRangeException>(ex);
    }

    [Fact]
    public void ElementAtShouldReturnHeadForZeroIndexAndLastForLastIndex()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(2);
        sut.Append(3);

        //act
        var head = sut.ElementAt(0);
        var last = sut.ElementAt(2);

        //assert
        Assert.Equal(1, head);
        Assert.Equal(3, last);
    }

    [Fact]
    public void GetNodeAt_ShouldReturnNullIfIndexOutOfRange()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Push(10);

        //act
        var current = sut.GetNodeAt(index: 0);
        var before = sut.GetNodeAt(index: -1);
        var after = sut.GetNodeAt(index: 1);

        //assert
        Assert.Equal(10, current!.data);
        Assert.Null(before);
        Assert.Null(after);
    }

    [Fact]
    public void DeleteAtFromEmptyLinkedList_ShouldThrowInvalidOperationException()
    {
        //arrange
        SinglyLinkedList sut = new();
        Action action = () => sut.DeleteAt(index: 0);

        //act
        var ex = Record.Exception(action);

        //assert
        Assert.IsType<InvalidOperationException>(ex);
    }

    [Fact]
    public void DeleteAtFromNonExistentIndex_ShouldThrowInvalidOperationException()
    {
        //arrange
        SinglyLinkedList sut = new();
        Action action = () => sut.DeleteAt(index: 0);

        //act
        var ex = Record.Exception(action);

        //assert
        Assert.IsType<InvalidOperationException>(ex);
    }

    [Fact]
    public void DeleteAtFromLastIndex_ShouldShrinkLinkedListFromRight()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(5);
        sut.Append(10);

        int indexToDelete = 2;
        object expectedValue = 5;

        //act
        sut.DeleteAt(indexToDelete);
        var last = sut.GetLast();

        //assert
        Assert.Equal(expectedValue, last);
    }

    [Fact]
    public void DeleteAtFromMiddle_ShouldExcludeSpecificNodeOnThatIndex()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(5);
        sut.Append(10);

        //act
        sut.DeleteAt(index: 1);
        var nextOfHead = sut.HeadAsNode!.next!.data;

        //assert
        Assert.Equal(10, nextOfHead);
    }

    [Fact]
    public void DeleteAtFromSingleSized_ShouldMakeLinkedListEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(10);

        //act
        sut.DeleteAt(0);

        //assert
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void DeleteAtWhenRemovingHead_ShouldShiftHeadToRight()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);

        //act
        sut.DeleteAt(0);
        var newHead = sut.GetHead();

        //assert
        Assert.Equal(10, newHead);
    }

    [Fact]
    public void DeleteAtWhenRemovingLast_ShouldShiftLastToLeft()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);

        //act
        sut.DeleteAt(2);
        var newLast = sut.GetLast();

        //assert
        Assert.Equal(10, newLast);
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueWhenEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();

        //act
        bool isEmpty = sut.IsEmpty;

        //assert
        Assert.True(isEmpty);
    }
    
    [Fact]
    public void IsEmpty_ShouldReturnFalseWhenNotEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(10);

        //act
        bool isEmpty = sut.IsEmpty;

        //assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void Clear_ShouldMakeLinkedListEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(10);
        sut.Append(20);
        sut.Append(30);
        sut.Append(40);

        //act
        sut.Clear();

        //assert
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void Reverse_ShouldSwapHeadAndLastPositions()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);
        sut.Append(30);

        var headBefore = sut.GetHead();
        var lastBefore = sut.GetLast();

        //act
        sut.Reverse();
        var headAfter = sut.GetHead();
        var lastAfter = sut.GetLast();

        //assert
        Assert.Equal(headBefore, lastAfter);
        Assert.Equal(lastBefore, headAfter);
    }

    [Fact]
    public void Reverse_ShouldNotThrowExceptionIfLinkedListIsEmpty()
    {
        //arrange
        SinglyLinkedList sut = new();
        Action action = () => sut.Reverse();

        //act
        var ex = Record.Exception(action);

        //assert
        Assert.Null(ex);

    }

    [Fact]
    public void Reverse_ElementInMiddleShouldRemainSame()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);
        sut.Append(30);
        sut.Append(40);

        var middleBefore = 20;

        //act
        sut.Reverse();
        var middleAfter = sut.HeadAsNode!.next!.next!.data;

        //
        Assert.Equal(middleBefore, middleAfter);
    }

    [Fact]
    public void Reverse_TwoMiddleElementsShouldSwapPositions()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);
        sut.Append(30);

        var secondBefore = 10;
        var thirdBefore = 20;

        //act
        sut.Reverse();
        var secondAfter = sut.HeadAsNode!.next!.data;
        var thirdAfter = sut.HeadAsNode!.next!.next!.data;

        //assert
        Assert.Equal(secondBefore, thirdAfter);
        Assert.Equal(thirdBefore, secondAfter);
    }

    [Fact]
    public void Reverse_EveryElementShouldChangeIndexAccordingly()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(10);
        sut.Append(20);
        sut.Append(30);
        sut.Append(40);

        var firstBefore = 1;
        var secondBefore = 10;
        var thirdBefore = 20;
        var fourthBefore = 30;
        var fifthBefore = 40;

        //act
        sut.Reverse();
        var firstAfter = sut.HeadAsNode!.data;
        var secondAfter = sut.HeadAsNode!.next!.data;
        var thirdAfter = sut.HeadAsNode!.next!.next!.data;
        var fourthAfter = sut.HeadAsNode!.next!.next!.next!.data;
        var fifthAfter = sut.HeadAsNode!.next!.next!.next!.next!.data;

        //assert
        Assert.Equal(firstBefore, fifthAfter);
        Assert.Equal(secondBefore, fourthAfter);
        Assert.Equal(thirdBefore, thirdAfter);
        Assert.Equal(fourthBefore, secondAfter);
        Assert.Equal(fifthBefore, firstAfter);
    }

    [Fact]
    public void GetSize_ShouldReturnValidAmountOfElementsInsideLinkedList()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(1);
        sut.Append(1);
        sut.Append(1);

        //act
        int size = sut.GetSize();

        //assert
        Assert.Equal(4, size);

    }

    [Fact]
    public void ShouldBeIterableCollection()
    {
        //arrange
        SinglyLinkedList sut = new();

        //act
        bool isEnumerable = sut is IEnumerable;

        //assert
        Assert.True(isEnumerable);
    }

    [Fact]
    public void ShouldDoAsMuchStepsAsLinkedListSize()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(2);
        sut.Append(3);

        int counter = default;
        int expected = sut.GetSize();

        //act
        foreach (var item in sut)
        {
            counter++;
        }

        //assert
        Assert.Equal(expected, counter);
    }

    [Fact]
    public void ShouldIterateOnRightElements()
    {
        //arrange
        SinglyLinkedList sut = new();
        sut.Append(1);
        sut.Append(2);
        sut.Append(3);

        int counter = default;

        //act && assert
        foreach (var item in sut)
        {
            if (counter == 0)
                Assert.Equal(1, item);
            else if (counter == 1)
                Assert.Equal(2, item);
            else if (counter == 2)
                Assert.Equal(3, item);

            counter++;
        }
    }

}
