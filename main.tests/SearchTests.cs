using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace main.tests;

public class SearchTests
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

    [Test]
    public void BFSGraphMatrixTest() // Doesnt know and idk why
    {
        var matrix = Utils.matrix;
        Assert.Multiple(() =>
        {
            var result = Search.BFSGraphMatrix(matrix, 0, 6);
            var expected = new[]{
                    0,
                    1,
                    4,
                    5,
                    6};
            Assert.AreEqual(result, expected);
            Assert.AreEqual(Search.BFSGraphMatrix(matrix, 6, 0), null);
        });
    }

    [Test]
    public void DFSGraphListTest()
    {
        var list = new List<List<GraphEdge>>();
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 1, weight = 3 }, new GraphEdge { to = 2, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 4, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 3, weight = 7 } });
        list.Add(new List<GraphEdge>());
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 1, weight = 1 }, new GraphEdge { to = 3, weight = 5 }, new GraphEdge { to = 5, weight = 2 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 2, weight = 18 }, new GraphEdge { to = 6, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 3, weight = 1 } });

        Assert.Multiple(() =>
        {
            Assert.AreEqual(Search.DFSGraphList(list, 0, 6), new[] { 0, 1, 4, 5, 6 });
            Assert.AreEqual(Search.DFSGraphList(list, 6, 0), null);
        });
    }

    [Test]
    public void DijkstraListTest() {
        var list = new List<List<GraphEdge>>();
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 1, weight = 3 }, new GraphEdge { to = 2, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 0, weight = 3 }, new GraphEdge { to = 2, weight = 4 }, new GraphEdge { to = 4, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 1, weight = 4 }, new GraphEdge { to = 3, weight = 7 }, new GraphEdge { to = 0, weight = 1 } });
        list.Add(new List<GraphEdge>() {new GraphEdge { to = 2, weight = 7 }, new GraphEdge { to = 4, weight = 5 }, new GraphEdge { to = 6, weight = 1 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 1, weight = 1 }, new GraphEdge { to = 3, weight = 5 }, new GraphEdge { to = 5, weight = 2 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 6, weight = 1 }, new GraphEdge { to = 4, weight = 2 }, new GraphEdge { to = 2, weight = 18 } });
        list.Add(new List<GraphEdge>() { new GraphEdge { to = 3, weight = 1 }, new GraphEdge { to = 5, weight = 1 } });

        Assert.AreEqual(Search.DijkstraList(0, 6, list), new[]{0, 1, 4, 5, 6});
    }
}
