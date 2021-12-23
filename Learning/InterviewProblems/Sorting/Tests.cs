using Common;
using NUnit.Framework;

namespace InterviewProblems.Sorting
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test()
        {
            int[] arr = { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

            Logger.Information("Original array : {@Array}", arr);
            
            QuickSort(arr, 0, arr.Length-1);
            
            Logger.Information("Sorted array : {@Array}", arr);
        }
        
        private static void QuickSort(int[] arr, int left, int right) 
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    QuickSort(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    QuickSort(arr, pivot + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true) 
            {
                while (arr[left] < pivot) 
                    left++;

                while (arr[right] > pivot) 
                    right--;

                if (left < right)
                {
                    if (arr[left] == arr[right]) 
                        return right;
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else 
                {
                    return right;
                }
            }
        }
    }
}