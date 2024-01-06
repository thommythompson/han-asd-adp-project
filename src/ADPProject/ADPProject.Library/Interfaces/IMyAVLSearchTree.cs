using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public interface IMyAVLSearchTree<T> : IConvertableFromArray<T> where T : IComparable<T>
{
    void Insert(T value);
    void Remove(T value);
    bool Find(T value);
    T FindMin();
    T FindMax();
    List<T> PreOrder();
    List<T> PostOrder();
    List<T> InOrder();
}