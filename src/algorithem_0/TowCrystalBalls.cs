public class TowCrystalBalls
{

    int[] arr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

    public static int[] GetBigTestArr()
    {
        var arr0 = Enumerable.Repeat(0, 250);
        var arr1 = Enumerable.Repeat(1, 34);
        var f = arr0.Concat(arr1).ToArray();

        return f;
    }


    public static int FindBrakingPoint(int[] input)
    {

        int sqrt = (int)Math.Sqrt(input.Length);
        for (int i = sqrt; i < input.Length; i += sqrt)
        {
            if (input[i] == 1)
            {
                for (int j = i - sqrt; j < i;j++)
                {
                    if (input[j] == 1)
                    {
                        return j;
                    }
                }
                return i;
            }
        }

        return -1;

    }
}