namespace main;
public record Point(int x, int y);

public class Search
{
    static public bool linearSearch(int[] haystack, int needle)
    {
        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle)
            {
                return true;
            }
        }
        return false;
    }

    static public bool binarySearch(int[] haystack, int needle)
    {

        var lo = 0;
        var hi = haystack.Length;

        do
        {
            int mid = lo + (hi - lo) / 2;
            var value = haystack[mid];

            if (value == needle)
            {
                return true;
            }
            else if (value > needle)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }

        } while (lo < hi);
        return false;
    }

    static public int twoCrystalBalls(bool[] breaks)
    {
        var jumpAmount = (int)Math.Sqrt(breaks.Length);
        var i = jumpAmount;
        for (; i < breaks.Length; i += jumpAmount)
        {
            if (breaks[i])
            {
                break;
            }
        }
        i -= jumpAmount;

        for (var j = 0; j < jumpAmount && i < breaks.Length; ++j, ++i)
        {
            if (breaks[i])
            {
                return i;

            }

        }
        return -1;

    }

    static int[] preOrderWalk(BinaryTree<int> current, List<int> path)
    {
        if (current == null)
        {
            return path.ToArray();
        }

        path.Add(current.value);

        preOrderWalk(current.left!, path);
        preOrderWalk(current.right!, path);

        return path.ToArray();
    }

    static public int[] preOrderSearch(BinaryTree<int> head)
    {
        return preOrderWalk(head, new List<int>());
    }

    static int[] inOrderWalk(BinaryTree<int> current, List<int> path)
    {
        if (current == null)
        {
            return path.ToArray();
        }


        inOrderWalk(current.left!, path);
        path.Add(current.value);
        inOrderWalk(current.right!, path);

        return path.ToArray();
    }

    static public int[] inOrderSearch(BinaryTree<int> head)
    {
        return inOrderWalk(head, new List<int>());
    }

    static int[] postOrderWalk(BinaryTree<int> current, List<int> path)
    {
        if (current == null)
        {
            return path.ToArray();
        }


        postOrderWalk(current.left!, path);
        postOrderWalk(current.right!, path);
        path.Add(current.value);

        return path.ToArray();
    }

    static public int[] postOrderSearch(BinaryTree<int> head)
    {
        return postOrderWalk(head, new List<int>());
    }

    static public int[]? BFSGraphMatrix(List<List<int>> graph, int source, int needle) // Doesnt know and idk why
    {
        var seen = Enumerable.Repeat(false, graph.Count).ToArray();
        var prev = Enumerable.Repeat(-1, graph.Count).ToArray();

        seen[source] = true;
        var q = new System.Collections.Queue();
        q.Enqueue(source);

        do
        {
            var curr = (int)q.Dequeue()!;

            if (curr == needle)
                break;

            var adjs = graph[curr];
            for (int i = 0; i < adjs.Count; i++)
            {
                if (adjs[i] == 0)
                    continue;

                if (seen[i])
                    continue;

                seen[i] = true;
                prev[i] = curr;
                q.Enqueue(i);
            }
        } while (q.Count > 0);

        var currNeedle = needle;

        var output = new List<int>();

        while (prev[currNeedle] != -1)
        {
            output.Add(currNeedle);
            currNeedle = prev[currNeedle];
        }


        if (output.Count > 0)
        {
            output.Reverse();
            var sourceArray = new[] { source };
            return sourceArray.Concat(output).ToArray();
        }

        return null;
    }
}

public class Sort
{
    static public void bubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }

            }
        }
    }

    private static void qs(int[] array, int lo, int hi)
    {

        if (lo >= hi)
        {
            return;
        }

        var pivotIdx = partition(array, lo, hi);
        qs(array, lo, pivotIdx - 1);
        qs(array, pivotIdx + 1, hi);
    }

    private static int partition(int[] array, int lo, int hi)
    {
        var pivot = array[hi];
        var idx = lo - 1;

        for (var i = lo; i < hi; i++)
        {
            if (array[i] <= pivot)
            {
                idx++;
                var temp = array[i];
                array[i] = array[idx];
                array[idx] = temp;
            }
        }
        idx++;
        array[hi] = array[idx];
        array[idx] = pivot;

        return idx;
    }

    static public void quickSort(int[] array)
    {
        qs(array, 0, array.Length - 1);

    }
}
