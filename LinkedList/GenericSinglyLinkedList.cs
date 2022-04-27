namespace LinkedList;

public class GenericSinglyLinkedList<T>
{

    private GenericNode<T>? _head;

    public GenericNode<T>? GetHead()
    {
        return _head;
    }

    public GenericNode<T>? GetLast()
    {
        if (_head is null)
            return null;

        var next = _head;
        while (next.next is not null)
        {
            next = next.next;
        }

        return next;
    }

    public GenericNode<T>? ElementAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Push(T obj)
    {
        var temp = _head;

        _head = new(obj);
        _head.next = temp;
    }

    public void Append(T obj)
    {
        GenericNode<T> newNode = new(obj);

        GenericNode<T>? last = GetLast();
        if (last is null)
        {
            _head = newNode;
            return;
        }
            
        last.next = newNode;

    }

}

public sealed class GenericNode<T>
{
    public T data;
    public GenericNode<T>? next;

    public GenericNode(T value)
    {
        data = value;
        next = default;
    }

}