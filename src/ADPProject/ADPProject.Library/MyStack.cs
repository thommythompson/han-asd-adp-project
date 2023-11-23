using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyStack<T> : IMyStack<T> where T : IComparable<T>
{
        private IMyList<T> elements { get; init; }
        
        public int Size => elements.Length;
        
        public MyStack()
        {
                elements = new MyDoublyLinkedList<T>();
        }

        public void Push(T item)
        {
                elements.Add(item);
        }

        public T Pop()
        {
                GuardAgainstEmptyStack();

                int lastIndex = elements.Length - 1;
                T popped = elements.Get(lastIndex);
                elements.RemoveByIndex(lastIndex);
                return popped;
        }

        public T Top()
        {
                GuardAgainstEmptyStack();
                
                int lastIndex = elements.Length - 1;
                T top = elements.Get(lastIndex);
                return top;
        }

        public T Peek()
        {
                return Top();
        }

        public bool IsEmpty()
        {
                return elements.Length == 0;
        }

        private void GuardAgainstEmptyStack()
        {
                if (IsEmpty())
                { 
                        throw new InvalidOperationException("The stack is empty.");
                }
        }

        public void ConvertFromArray(T[] array)
        {
                for (int i = 0; i < array.Length; i++)
                {
                        var value = array[i];
            
                        this.Push(value);
                }
        }
        
        public void ConvertFromNullableArray(T?[] array)
        {
                for (int i = 0; i < array.Length; i++)
                {
                        var value = array[i];

                        if(null == value) 
                                continue;
            
                        this.Push(value);
                }
        }
}