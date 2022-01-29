namespace Queue;

internal interface IDequeueStrategy
{
    object[] GetModifiedMemory(object[] memory);
}
