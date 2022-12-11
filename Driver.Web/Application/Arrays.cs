using Arrays;
using Driver.Web.Application.Contracts;

namespace Driver.Web.Application{
   
    public class Arrays : IArrays
    {
		Solution s = new Solution();
        public int[] RotateLeft(int[] arr, int n, int k)
        {
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newPos = (i + n + k) % n;
                rotatedArray[i] = arr[newPos];
            }

            return rotatedArray;
        }

        public List<int> RotateLeft(List<int> arr, int n, int k)
        {
            List<int> rotatedArray = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int newPos = (i + n + k) % n;
                rotatedArray.Add(arr[newPos]);
            }

            return rotatedArray;
        }

        public int[] RotateRight(int[] arr, int n, int k)
        {
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newPos = (i + n - k) % n;
                rotatedArray[i] = arr[newPos];
            }

            return rotatedArray;
        }

        public List<int> RotateRight(List<int> arr, int n, int k)
        {
            List<int> rotatedArray = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int newPos = (i + n - k) % n;
                rotatedArray.Add(arr[newPos]);
            }

            return rotatedArray;
        }

        public int[] Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;

                start++;
                end--;
            }
            return arr;
        }

        /*Given N array elements, count no of elements having atleast 1 element greater than itself
		...So the logic is like this, if we find max element of the array, all other numbers will have 
		atleast 1 element greater than itself...
		*/
        public int CountAtleast1GreaterElement(int[] arr, int N)
        {
            //brute force
            // int count = 0;
            // for (int i = 0; i < N; i++)
            // {
            // 	for (int j = 0; j < N; j++)
            // 	{
            // 		if(arr[i] < arr[j]){
            // 			count++;
            // 			break;
            // 		}
            // 	}
            // }

            int max = arr[0];
            int maxCount = 1;
            for (int i = 1; i < N; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxCount = 1;
                }
                else if (arr[i] == max)
                {
                    maxCount++;
                }
            }

            //find no of occurence of max element
            // for (int i = 0; i < N; i++)
            // {
            // 	if(arr[i] == max){
            // 		maxCount++;
            // 	}
            // }
            return N - maxCount;
        }

        /*Given N array elements, check if there exists a pair i, j such that ar[i]+a[j]==k, i!=j
		*/
        public bool CheckSumPair(int[] arr, int N, int k)
        {
            bool flag = false;

            //brute force
            // for (int i = 0; i < N; i++)
            // {
            // 	for (int j = 0; j < N; j++)
            // 	{
            // 		if(i!= j && arr[i] + arr[j] == k){
            // 			flag = true;
            // 			break;
            // 		}
            // 	}
            // 	if(flag){
            // 		break;
            // 	}
            // }

            // in brute force we are checking all the pairs, which are repetitive, so instead we can only check lower triangle or upper triangle, 
            // complexity is still N^2 but iterations are less

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i != j && arr[i] + arr[j] == k)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }

            return flag;
        }

        public int Max(int[] arr, int N)
        {
            int Max = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                if (arr[i] > Max)
                {
                    Max = arr[i];
                }
            }
            return Max;
        }

        public int SecondMax(int[] arr, int N)
        {
            int Max = int.MinValue;
            int SecondMax = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                if (arr[i] > Max)
                {
                    Max = arr[i];
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (arr[i] > SecondMax && arr[i] != Max)
                {
                    SecondMax = arr[i];
                }
            }
            return SecondMax;
        }

        public int Min(int[] arr, int N)
        {
            int Min = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                if (arr[i] < Min)
                {
                    Min = arr[i];
                }
            }
            return Min;
        }


        /*Little Ponny is given an array, A, of N integers. 
		In a particular operation, he can set any element of the array equal to -1.
		He wants your help in finding out the minimum number of operations required such that the maximum element of the 
		resulting array is B. If it is not possible, then return -1.

		Understanding the question -- there are 2 inputs, 1 array of integers lets say A and another integer B
		question is asking the no of elements greater than B in array of integers A --> which can be reset to -1 making B 
		as largest element, if B is not present in arary of integers A --> meaning there is no way B can be made the 
		largest elment of the array so return -1
		*/

        /*Pick from 2 sides, pick subarray of a given size which has maximum sum
		
		Solution thought -- we need to compare sum, we can make prefix sum array, we need to pick up elements
		from both sides, so for sum of elements from last, we may need suffix sum array also
		*/
        public int PickFromBothSides(int[] arr, int N, int B)
        {

            int[] pfSumArr = s.GetPrefixSumArray(arr, N);
            int[] sfSumArr = s.GetSuffixSumArray(arr, N);

            int maxSubArrSum = int.MinValue;
            for (int i = 0; i <= B; i++)
            {
                int sum = (i == 0 ? 0 : pfSumArr[i - 1]) + (i == B ? 0 : sfSumArr[N - B + i]);
                maxSubArrSum = Math.Max(maxSubArrSum, sum);
            }
            return maxSubArrSum;
        }

        public int PickFromBothSides2(int[] arr, int N, int B)
        {

            int[] arr1 = new int[2 * N];
            for (int i = 0; i < 2 * N; i++)
            {
                arr1[i] = arr[i % N];
            }

            // get first sum
            int sum = 0;
            for (int i = N - B; i < N; i++)
            {
                sum += arr1[i];
            }
            int maxSubArrSum = sum;
            for (int i = N - B + 1; i < 2 * N - B; i++)
            {
                sum = sum - arr1[i - 1] + arr1[i + B - 1];
                maxSubArrSum = Math.Max(maxSubArrSum, sum);
            }

            return maxSubArrSum;
        }

        public int PickFromBothSides2List(List<int> arr, int N, int B)
        {

            List<int> arr1 = new List<int>();
            for (int i = 0; i < 2 * N; i++)
            {
                arr1.Add(arr[i % N]);
            }

            // get first sum
            int sum = 0;
            for (int i = N - B; i < N; i++)
            {
                sum += arr1[i];
            }
            int maxSubArrSum = sum;
            for (int i = N - B + 1; i < 2 * N - B; i++)
            {
                sum = sum - arr1[i - 1] + arr1[i + B - 1];
                maxSubArrSum = Math.Max(maxSubArrSum, sum);
            }

            return maxSubArrSum;
        }
    }
}
