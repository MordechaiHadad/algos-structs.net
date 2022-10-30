﻿namespace main;
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
