using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyDoublyLinkedList<T> : IMyList<T> where T : IComparable<T>
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
    private int _itemsInList;

    public MyDoublyLinkedList()
    {
        _itemsInList = 0;
    }
    
    public int Length { get => _itemsInList; }
    
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
        
        _itemsInList++;
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

    public void RemoveByIndex(int index)
    {
        Node node = GetNodeByIndex(index);
        
        RemoveNode(node);
    }

    public void RemoveByValue(T value)
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
            if (current.Value.CompareTo(value) == 0)
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
        }
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        _itemsInList--;
    }
    
    private Node? GetNodeByValue(T value)
    {
        Node current = _head;
        
        while (current != null)
        {
            if (value.CompareTo(current.Value) == 0)
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
        if (index < 0 || index >= _itemsInList)
            throw new IndexOutOfRangeException($"Index {index} is out of range, cannot be below 0 or above {_itemsInList}");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _itemsInList - 1; ++i)
            yield return Get(i);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void ConvertFromArray(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            this.Add(value);
        }
    }
}