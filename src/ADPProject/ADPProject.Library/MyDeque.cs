using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyDeque<T> : IMyDeque<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    
    private Node _head;
    private Node _tail;
    private int _itemsInQueue;
    
    public MyDeque()
    {
        _itemsInQueue = 0;
    }
    
    public int Size { get => _itemsInQueue; }
    
    public void InsertLeft(T item)
    {
        Node newNode = new Node(item);
        if (IsEmpty())
            SetFirstNode(newNode);
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        _itemsInQueue++;
    }

    public void InsertRight(T item)
    {
        Node newNode = new Node(item);
        
        if (IsEmpty())
            SetFirstNode(newNode);
        else
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
        _itemsInQueue++;
    }

    public T DeleteLeft()
    {
        GuardAgainstEmptyQueue();
        
        T removed = _head.Value;
        _head = _head.Next;
        if (_head != null)
        {
            _head.Previous = null;
        }
        else
        {
            _tail = null;
        }

        _itemsInQueue--;
        return removed;
    }

    public T DeleteRight()
    {
        GuardAgainstEmptyQueue();
        
        T removed = _tail.Value;
        _tail = _tail.Previous;
        if (_tail != null)
        {
            _tail.Next = null;
        }
        else
        {
            _head = null;
        }
        
        _itemsInQueue--;
        return removed;
    }

    private void SetFirstNode(Node node)
    {
        _head = node;
        _tail = node;
    }
    private bool IsEmpty()
    {
        return null == _tail && null == _head;
    }
    private void GuardAgainstEmptyQueue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The deque is empty.");
        }
    }
}