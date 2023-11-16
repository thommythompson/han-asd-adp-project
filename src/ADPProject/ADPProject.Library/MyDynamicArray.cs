﻿using System.Net.Sockets;

namespace ADPProject.Library;

public interface IMyDynamicArray<T>
{
    public int Length { get; }
    public int Capacity { get; }
    public void Add(T value);
    public T Get(int index);
    public void Set(int index, T value);
    public void RemoveByIndex(int index);
    public void RemoveByValue(T value);
    public bool Contains(T value);
    public int IndexOf(T value);
}

public class MyDynamicArray<T> : IMyDynamicArray<T> 
{
    private readonly int _initialCapacity = 8;
    
    private T[] _array;
    private int _valuesInArray;
    private int _capacity;
    
    public int Length { get => _valuesInArray; }
    public int Capacity { get => _capacity; }
    
    public MyDynamicArray()
    {
        _capacity = _initialCapacity;
        _array = new T[_capacity];
        _valuesInArray = 0;
    }
    
    public void Add(T value)
    {
        if (_valuesInArray == _capacity)
        {
            _capacity = (_capacity * 2);
            T[] newArray = new T[_capacity];
            Array.Copy(_array, newArray, _valuesInArray);
            _array = newArray;
        }

        _array[_valuesInArray] = value;
        _valuesInArray++;
    }

    public T Get(int index)
    {
        CheckIfIndexOutOfRange(index);

        return _array[index];
    }

    public void Set(int index, T value)
    {
        CheckIfIndexOutOfRange(index);

        _array[index] = value;
    }

    public void RemoveByIndex(int index)
    {
        CheckIfIndexOutOfRange(index);
        
        for (int i = index; i < (_valuesInArray - 1); i++)
        {
            _array[i] = _array[i + 1];
        }

        _valuesInArray--;
    }

    public void RemoveByValue(T value)
    {
        int index = IndexOf(value);

        RemoveByIndex(index);
    }

    public bool Contains(T value)
    {
        try
        {
            _ = IndexOf(value);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public int IndexOf(T value)
    {
        int index = -1;

        for (int i = 0; i < _valuesInArray; i++)
        {
            if (value.Equals(_array[i]))
            {
                index = i;
            }
        }

        if (-1 == index)
        {
            throw new KeyNotFoundException("The value is not found within this array");
        }

        return index;
    }

    private void CheckIfIndexOutOfRange(int index)
    {
        if (index < 0 || index >= _valuesInArray)
            throw new IndexOutOfRangeException($"Index {index} is out of range, cannot be below 0 or above {_valuesInArray}");
    }
}