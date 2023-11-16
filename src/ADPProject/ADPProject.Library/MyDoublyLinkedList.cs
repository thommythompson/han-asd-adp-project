namespace ADPProject.Library;

interface IMyDoublyLinkedList<T>
{
    public int Length { get; }
    public void Add(T value);
    public T Get(int index);
    public void Set(int index, T value);
    public void Remove(int index);
    public void Remove(T value);
    public bool Contains(T value);
    public int IndexOf(T value);
}

public class MyDoublyLinkedList<T> : IMyDoublyLinkedList<T>
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
    private int _count;
    
    public int Length { get => _count; }
    
    public void Add(T value)
    {
        Node newNode = new Node(value);
        
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
        
        _count++;
    }

    public T Get(int index)
    {
        Node node = GetNodeByIndex(index);

        return node.Value;
    }

    public void Set(int index, T value)
    {
        Node node = GetNodeByIndex(index);

        node.Value = value;
    }

    public void Remove(int index)
    {
        Node node = GetNodeByIndex(index);
        
        RemoveNode(node);
    }

    public void Remove(T value)
    {
        Node node = GetNodeByValue(value);
        
        RemoveNode(node);
    }

    public bool Contains(T value)
    {
        if (null == GetNodeByValue(value))
            return false;

        return true;
    }

    public int IndexOf(T value)
    {
        Node current = _head;
        int index = 0;
        
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return index;
            }
            current = current.Next;
            index++;
        }

        throw new KeyNotFoundException("Value not found");
    }

    private void RemoveNode(Node node)
    {
        if (node == _head)
        {
            _head = _head.Next;

            if (_head != null)
            {
                _head.Previous = null;
            }
            else
            {
                _tail = null;
            }
        }
        else if (node == _tail)
        {
            _tail = _tail.Previous;
            _tail.Next = null;
            return;
        }
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        _count--;
    }
    
    private Node? GetNodeByValue(T value)
    {
        Node current = _head;
        
        while (current != null)
        {
            if (value.Equals(current.Value))
            {
                return current;
            }
            current = current.Next;
        }
        
        return null;
    }
    
    private Node GetNodeByIndex(int index)
    {
        CheckIfIndexOutOfRange(index);
        
        Node current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current;
    }
    
    private void CheckIfIndexOutOfRange(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException($"Index {index} is out of range, cannot be below 0 or above {_count}");
    }
}