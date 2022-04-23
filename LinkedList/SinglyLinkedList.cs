namespace LinkedList;

public class SinglyLinkedList
{

    private Node? _head;

    public SinglyLinkedList()
    {
        _head = default;
    }

    public object? GetHead()
    {
        return _head?.data;
    }

    public object? GetLast()
    {
        return GetLastNode()?.data;
    }

    public void Append(object o)
    {
        if (_head is null)
        {
            _head = new(o);
            return;
        }

        Node last = GetLastNode()!;
        last.next = new Node(o);
    }

    private Node? GetLastNode()
    {
        Node? last = _head;
        while (last?.next != null)
        {
            last = last.next;
        }

        return last;
    }

    public void Push(object o)
    {
        Node newNode = new(o);

        newNode.next = _head;

        _head = newNode;
    }

    public void InsertAfter(int index, object value)
    {
        if (IsOutOfRange(index))
        {
            throw new IndexOutOfRangeException();
        }
        
        if (IsOnTheEdge())
        {
            Append(value);
            return;
        }
        
        Node next = _head!;
        while (index > 0)
        {
            next = next!.next!;
            index--;
        }

        Node newNode = new(value);
        newNode.next = next.next;
        next.next = newNode;


        bool IsOnTheEdge() => GetSize() == 0 || index == GetSize() - 1;
    }

    public object ElementAt(int index)
    {
        if (IsOutOfRange(index))
        {
            throw new IndexOutOfRangeException();
        }

        Node next = _head!;
        while (index > 0)
        {
            next = next.next!;
            index--;
        }

        return next.data;

    }

    private bool IsOutOfRange(int index)
    {
        int indexOfLast = GetSize() - 1;
        bool isEmpty = indexOfLast == -1;

        return index < 0 || isEmpty || indexOfLast < index;
    }

    private int GetSize()
    {
        int count = 0;
        Node? next = _head;

        while (next is not null)
        {
            count++;
            next = next.next;
        }
        return count;
    }

}

internal class Node
{
    public object data;
    public Node? next;

    public Node(object o)
    {
        data = o;
        next = default;
    }

}