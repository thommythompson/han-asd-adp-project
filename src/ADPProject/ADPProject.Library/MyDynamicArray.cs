using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyDynamicArray<T> : IMyList<T> where T : IComparable<T>
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
        for (int i = 0; i < _valuesInArray; i++)
        {
            if (value.CompareTo(_array[i]) == 0)
            {
                return i;
            }
        }
        
        throw new KeyNotFoundException("The value is not found within this array");
    }

    private void CheckIfIndexOutOfRange(int index)
    {
        if (index < 0 || index >= _valuesInArray)
            throw new IndexOutOfRangeException($"Index {index} is out of range, cannot be below 0 or above {_valuesInArray}");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _valuesInArray - 1; ++i)
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
    
    public void ConvertFromNullableArray(T?[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];

            if(null == value) 
                continue;
            
            this.Add(value);
        }
    }
}