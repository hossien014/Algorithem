
public class AlgorithemTests
{

    [Fact]
    public void BinarySerach_N_Test()
    {
        // Given

        int[] arr1 = Enumerable.Range(1, 10).ToArray();
        // int[] arr1 = { 1,2,3,4,5,6,7,8,9,10 };
        
        int target1 = 5;
        int expetedIndex1 = 4;


        // When
        var act = BinarySearch.BinarySerach_N(arr1, target1);

        // Then
        Assert.Equal(expetedIndex1, act);

    }



}