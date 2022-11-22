using NUnit.Framework;
using System;
using System.Linq;

namespace main.tests;

public class SortTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BubbleSortTest()
    {
        int[] array = { 9, 3, 7, 4, 69, 420, 42 };
        Sort.bubbleSort(array);
        int[] sorted_array = { 3, 4, 7, 9, 42, 69, 420 };
        Assert.AreEqual(array, sorted_array);
    }

    [Test]
    public void QuickSortTest()
    {
        int[] array = { 9, 3, 7, 4, 69, 420, 42 };
        int[] sortedArray = { 3, 4, 7, 9, 42, 69, 420 };

        Sort.quickSort(array);
        Assert.AreEqual(array, sortedArray);
    }
}
