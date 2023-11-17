using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests.Extensions;

public static class MyListExtensions
{
    public static IMyList<T> ConvertFromArray<T>(this IMyList<T> myArray, T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            myArray.Add(value);
        }

        return myArray;
    }
}