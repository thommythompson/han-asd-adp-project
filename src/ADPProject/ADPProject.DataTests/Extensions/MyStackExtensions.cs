using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests.Extensions;

public static class MyStackExtensions
{
    public static IMyStack<T> ConvertFromArray<T>(this IMyStack<T> myStack, T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            myStack.Push(value);
        }

        return myStack;
    }
}