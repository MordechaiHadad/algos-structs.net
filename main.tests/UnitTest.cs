using NUnit.Framework;
using System;
using System.Linq;

namespace main.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(69, true)]
    [TestCase(1336, false)]
    [TestCase(69420, true)]
    [TestCase(69421, false)]
    [TestCase(1, true)]
    [TestCase(0, false)]
    public void LinearSearchTest(int value, bool value1)
    {
        int[] result = { 1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420 };
        Assert.AreEqual(Search.linearSearch(result, value), value1);
    }

    [Test]
    [TestCase(69, true)]
    [TestCase(1336, false)]
    [TestCase(69420, true)]
    [TestCase(69421, false)]
    [TestCase(1, true)]
    [TestCase(0, false)]
    public void BinarySearchTest(int value, bool value1)
    {
        int[] result = { 1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420 };
        Assert.AreEqual(Search.binarySearch(result, value), value1);
    }

    [Test]
    public void TwoCrystalBallsTestEqual()
    {
        var rand = new Random();
        int idx = (int)rand.NextDouble() * 10000;

        var data = Enumerable.Repeat(false, 10000).ToArray();


        for (var i = idx; i < 10000; ++i)
        {
            data[i] = true;
        }

        Assert.AreEqual(Search.twoCrystalBalls(data), idx);
    }

    [Test]
    public void TwoCrystalBallsTestNegative()
    {
        Assert.AreEqual(Search.twoCrystalBalls(Enumerable.Repeat(false, 821).ToArray()), -1);
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
    public void QueueLengthTest()
    {
        var list = new Queue<int>();
        list.enqeue(4);
        list.enqeue(1);
        list.enqeue(30);
        list.deque();

        Assert.AreEqual(list.length, 2);

    }

    [Test]
    public void QueueDequeTest()
    {
        var list = new Queue<int>();
        list.enqeue(4);
        list.enqeue(1);
        list.enqeue(30);
        list.deque();
        list.deque();

        Assert.AreEqual(list.deque(), 30);
    }

    [Test]
    public void QueuePeekTest()
    {
        var list = new Queue<int>();
        list.enqeue(4);
        list.enqeue(1);
        list.enqeue(30);

        Assert.AreEqual(list.peek(), 4);
    }
}
