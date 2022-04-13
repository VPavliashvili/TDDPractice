namespace Queue;

internal interface IDequeueStrategy<T>
{
    T[] GetModifiedMemory(T[] memory);
}
