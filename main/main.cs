namespace main;
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

    static public bool binarySearch(int[] haystack, int needle) {

        var lo = 0;
        var hi = haystack.Length;

        do
        {
            int mid = lo + (hi - lo) / 2;
            var value = haystack[mid];

            if(value == needle) {
                return true;
            } else if(value > needle) {
                hi = mid;
            } else {
                lo = mid + 1;
            }
            
        } while (lo < hi);
        return false;
    }

    static public int twoCrystalBalls(bool[] breaks) {
        var jumpAmount = (int)Math.Sqrt(breaks.Length);
        var i = jumpAmount;
        for(; i < breaks.Length; i += jumpAmount) {
            if(breaks[i]) {
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
