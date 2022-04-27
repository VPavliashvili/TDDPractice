using LinkedList;
using System;
using System.Reflection;
using Xunit;

namespace Tests;

public class GenericSinglyLinkedListTests
{

    [Fact]
    public void GetHead_ShouldReturnNullWhenEmpty()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();

        //act
        var head = sut.GetHead();

        //assert
        Assert.Null(head);
    }

    [Fact]
    public void GetHead_ShouldReturnFirstElement()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Push(1);

        //act
        var head = sut.GetHead();

        //assert
        Assert.Equal(1, head!.data);
    }

    [Fact]
    public void GetLast_ShouldReturnNullWhenEmpty()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();

        //act
        var last = sut.GetLast();

        //assert
        Assert.Null(last);
    }

    [Fact]
    public void GetLast_ShouldReturnLastElement()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);

        //act
        var last = sut.GetLast();

        //assert
        Assert.Equal(1, last!.data);
    }

    [Fact]
    public void GetLastAndGetHead_ShouldReturnSameIfOnlyOneElement()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Push(1);

        //act
        var last = sut.GetLast();
        var head = sut.GetHead();

        //assert
        Assert.Equal(1, last!.data);
        Assert.Equal(1, head!.data);
    }

    [Fact]
    public void GetLastAndGetHead_ShouldNotReturnSameIfMoreThanOneElement()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Push(1);
        sut.Push(2);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //assert
        Assert.Equal(2, head!.data);
        Assert.Equal(1, last!.data);
    }

    [Fact]
    public void Push_ShouldInsertElementAtTheStart()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);

        //act
        var head = sut.GetHead();
        var last = sut.GetLast();

        //assert
        Assert.Equal(3, head!.data);
        Assert.Equal(1, last!.data);
    }

    [Fact]
    public void Append_ShouldInsertElementAtTheEnd()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Append(1);
        sut.Append(2);
        sut.Append(3);

        //act
        var last = sut.GetLast();
        var head = sut.GetHead();

        //assert
        Assert.Equal(3, last!.data);
        Assert.Equal(1, head!.data);
    }

    [Fact]
    public void Append_ShouldInsertAsHeadAndLastWhenEmpty()
    {
        //arrange
        GenericSinglyLinkedList<object> sut = new();
        sut.Append(1);

        //act
        var last = sut.GetLast()!.data;
        var head = sut.GetHead()!.data;

        //assert
        Assert.Equal(1, last);
        Assert.Equal(1, head);
    }

    [Fact]
    public void ReturnedElementTypeFromLinkedList_ShouldBeGenericNode()
    {
        //arrange
        GenericSinglyLinkedList<int> sut = new();
        string expectedTypeName = typeof(GenericNode<int>).Name;

        //act
        MethodInfo getHeadMethod = typeof(GenericSinglyLinkedList<int>).GetMethod(nameof(sut.GetHead))!;
        string headTypeName = getHeadMethod!.ReturnType.Name;

        MethodInfo getLastMethod = typeof(GenericSinglyLinkedList<int>).GetMethod(nameof(sut.GetLast))!;
        string lastTypeName = getLastMethod!.ReturnType.Name;

        MethodInfo elementAtMethod = typeof(GenericSinglyLinkedList<int>).GetMethod(nameof(sut.ElementAt))!;
        string elementAtTypeName = elementAtMethod!.ReturnType.Name;

        //assert
        Assert.Equal(expectedTypeName, headTypeName);
        Assert.Equal(expectedTypeName, lastTypeName);
        Assert.Equal(expectedTypeName, elementAtTypeName);
    }

}
