using NUnit.Framework;
using System;
using System.Linq;

namespace main.tests;

public class DatastructsTests
{
    [SetUp]
    public void Setup()
    {
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
    public void MinHeapTest()
    {
        var heap = new MinHeap();

        Assert.Multiple(() =>
        {
            Assert.AreEqual(heap.length, 0);
            heap.insert(5);
            heap.insert(3);
            heap.insert(69);
            heap.insert(420);
            heap.insert(4);
            heap.insert(1);
            heap.insert(8);
            heap.insert(7);

            Assert.AreEqual(heap.length, 8);
            Assert.AreEqual(heap.delete(), 1);
            Assert.AreEqual(heap.delete(), 3);
            Assert.AreEqual(heap.delete(), 4);
            Assert.AreEqual(heap.delete(), 5);
            Assert.AreEqual(heap.length, 4);
        });
    }

    [Test]
    public void LRUTest()
    {
        var lru = new LRU<string, int>(3);

        Assert.Multiple(() =>
        {
            Assert.AreEqual(lru.get("foo"), 0);
            lru.update("foo", 69);
            Assert.AreEqual(lru.get("foo"), 69);

            lru.update("bar", 420);
            Assert.AreEqual(lru.get("bar"), 420);

            lru.update("baz", 1337);
            Assert.AreEqual(lru.get("baz"), 1337);

            lru.update("ball", 69420);
            Assert.AreEqual(lru.get("ball"), 69420);
            Assert.AreEqual(lru.get("foo"), 0);
            Assert.AreEqual(lru.get("bar"), 420);

            lru.update("foo", 69);
            Assert.AreEqual(lru.get("bar"), 420);
            Assert.AreEqual(lru.get("foo"), 69);

            Assert.AreEqual(lru.get("baz"), 0);
        });
    }
}
