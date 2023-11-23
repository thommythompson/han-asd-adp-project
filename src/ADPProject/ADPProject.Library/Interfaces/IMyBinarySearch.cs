namespace ADPProject.Library.Interfaces;

public interface IMyBinarySearch<T> : IConvertableFromArray<T> where T : IComparable<T?> 
{
     public int Search(T target);
}