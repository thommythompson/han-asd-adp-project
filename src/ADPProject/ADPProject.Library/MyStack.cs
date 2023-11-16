namespace ADPProject.Library;

public interface IMyStack<T>
{
        int Size { get; }
        void Push(T item);
        void Pop(T item);
        void Top();
        void Peek();
        bool IsEmpty();
}

public class MyStack<T> : IMyStack<T>
{
        public int Size { get; }
        
        public void Push(T item)
        {
                throw new NotImplementedException();
        }

        public void Pop(T item)
        {
                throw new NotImplementedException();
        }

        public void Top()
        {
                throw new NotImplementedException();
        }

        public void Peek()
        {
                throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
                throw new NotImplementedException();
        }
}