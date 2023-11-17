using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests.Extensions;

public static class MyDequeExtensions
{
    public static IMyDeque<T> ConvertFromArray<T>(this IMyDeque<T> myDeque, T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            myDeque.InsertRight(value);
        }

        return myDeque;
    }
}