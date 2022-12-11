namespace Driver.Web.Application.Contracts
{
    public interface IArrays
    {
        bool CheckSumPair(int[] arr, int N, int k);
        int CountAtleast1GreaterElement(int[] arr, int N);
        int Max(int[] arr, int N);
        int Min(int[] arr, int N);
        int PickFromBothSides(int[] arr, int N, int B);
        int PickFromBothSides2(int[] arr, int N, int B);
        int PickFromBothSides2List(List<int> arr, int N, int B);
        int[] Reverse(int[] arr, int start, int end);
        int[] RotateLeft(int[] arr, int n, int k);
        List<int> RotateLeft(List<int> arr, int n, int k);
        int[] RotateRight(int[] arr, int n, int k);
        List<int> RotateRight(List<int> arr, int n, int k);
        int SecondMax(int[] arr, int N);
    }
}