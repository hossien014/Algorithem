
using System.Reflection.Metadata.Ecma335;

public class BinarySearch
{

    public static int BinarySerach_N(int[] arr, int target)
    {

        int high = arr.Length;
        int low = 0;
        int midlle_value;
        int midlle_index;

        while (low < high)
        {
            midlle_index = low + (high - low) / 2;
            midlle_value = arr[midlle_index];
            if (target == midlle_value) return midlle_index;

            else if (target > midlle_value)
            {
                low = midlle_index + 1;
            }
            else
            {
                high = midlle_index;
            }
        }

        return -1;
    }

  
}


