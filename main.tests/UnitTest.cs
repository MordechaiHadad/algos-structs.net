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

    [Test]
    public void StackLengthTest()
    {
        var list = new Stack<int>();
        list.push(4);
        list.push(1);
        list.push(30);
        list.pop();

        Assert.AreEqual(list.length, 2);
    }

    [Test]
    public void StackPopTest()
    {
        var list = new Stack<int>();
        list.push(4);
        list.push(1);
        list.push(30);
        list.pop();
        list.pop();

        Assert.AreEqual(list.pop(), 4);
    }

    [Test]
    public void StackPeekTest()
    {
        var list = new Stack<int>();
        list.push(4);
        list.push(1);
        list.push(30);

        Assert.AreEqual(list.peek(), 30);
    }

    [Test]
    public void QuickSortTest()
    {
        int[] array = { 9, 3, 7, 4, 69, 420, 42 };
        int[] sortedArray = { 3, 4, 7, 9, 42, 69, 420 };

        Sort.quickSort(array);
        Assert.AreEqual(array, sortedArray);
    }

    [Test]
    public void DoublyLinkedListTest()
    {
        var list = new DoublyLinkedList<int>();
        list.append(5);
        list.append(7);
        list.append(9);

        Assert.Multiple(() =>
        {
            Assert.AreEqual(list.get(2), 9);
            Assert.AreEqual(list.removeAt(1), 7);
            Assert.AreEqual(list.length, 2);
            list.append(11);
            Assert.AreEqual(list.removeAt(1), 9);
        });

    }

    [Test]
    public void PreOrderTest()
    {
        var tree = Utils.tree;
        var result = Search.preOrderSearch(tree);
        Assert.AreEqual(result, new int[]{
        20,
        10,
        5,
        7,
        15,
        50,
        30,
        29,
        45,
        100});
    }

    [Test]
    public void PostOrderTest()
    {
        var tree = Utils.tree;
        Assert.AreEqual(Search.postOrderSearch(tree), new int[]{
        7,
        5,
        15,
        10,
        29,
        45,
        30,
        100,
        50,
        20});
    }

    [Test]
    public void InOrderTest()
    {
        var tree = Utils.tree;
        Assert.AreEqual(Search.inOrderSearch(tree), new int[]{
        5,
        7,
        10,
        15,
        20,
        29,
        30,
        45,
        50,
        100});
    }
}
