namespace CodingProblems
{
    public class QuickSortNew
    {
        private int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (numbers[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    var temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private void QuickSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(numbers, left, right);

                if (pivot > 1)
                {
                    QuickSort(numbers, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort(numbers, pivot + 1, right);
                }
            }
        }
    }
}
