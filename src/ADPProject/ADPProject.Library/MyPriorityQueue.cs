using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyPriorityQueue<T> : IMyPriorityQueue<T>
{
    private IMyPriorityQueue<T> _myPriorityQueueImplementation;

    private class PrioritizedItem : IComparable<PrioritizedItem>
    {
        public int Priority { get; init; }
        public T Item { get; init; }
        
        public PrioritizedItem(int priority, T item)
        {
            Priority = priority;
            Item = item;
        }

        public int CompareTo(PrioritizedItem? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Priority.CompareTo(other.Priority);
        }
    }
    
    private IMyList<PrioritizedItem> _heap { get; init; }

    public MyPriorityQueue()
    {
        _heap = new MyDynamicArray<PrioritizedItem>();
    }
    
    public void Insert(int priority, T item)
    {
        _heap.Add(new PrioritizedItem(priority, item));
        HeapifyUp(_heap.Length - 1);
    }
    
    public T FindMin()
    {
        GuardAgainstEmptyQueue();

        return _heap.Get(0).Item;
    }
    
    public T DeleteMin()
    {
        GuardAgainstEmptyQueue();

        PrioritizedItem minItem = _heap.Get(0);
        int lastIndex = _heap.Length - 1;
        _heap.Set(0, _heap.Get(lastIndex));
        _heap.RemoveByIndex(lastIndex);

        HeapifyDown(0);

        return minItem.Item;
    }
    
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_heap.Get(parentIndex).CompareTo(_heap.Get(index)) <= 0)
                break;

            Swap(parentIndex, index);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            int smallestChildIndex = index;

            if (leftChildIndex < _heap.Length && _heap.Get(leftChildIndex).CompareTo(_heap.Get(smallestChildIndex)) < 0)
                smallestChildIndex = leftChildIndex;

            if (rightChildIndex < _heap.Length && _heap.Get(rightChildIndex).CompareTo(_heap.Get(smallestChildIndex)) < 0)
                smallestChildIndex = rightChildIndex;

            if (smallestChildIndex == index)
                break;

            Swap(index, smallestChildIndex);
            index = smallestChildIndex;
        }
    }
    
    private void Swap(int i, int j)
    {
        PrioritizedItem temp = _heap.Get(i);
        _heap.Set(i, _heap.Get(j));
        _heap.Set(j, temp);
    }

    private void GuardAgainstEmptyQueue()
    {
        if (_heap.Length == 0)
            throw new InvalidOperationException("The queue is empty.");
    }

    public void ConvertFromArray(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            this.Insert(i, value);
        }
    }
}