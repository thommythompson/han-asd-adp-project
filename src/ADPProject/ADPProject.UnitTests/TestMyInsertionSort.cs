﻿using ADPProject.Library.Interfaces;
using ADPProject.Tests.BaseTests;


namespace ADPProject.Tests;

public class TestMyInsertionSort : IMySortedListBaseTest
{
    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MyInsertionSort<T>(list);
    }
}