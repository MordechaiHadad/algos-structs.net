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
}
