namespace CodingProblems
{
    public class QuickSort
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
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public void QuickSortRecursive(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(numbers, left, right);

                if (pivot > 1)
                {
                    QuickSortRecursive(numbers, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSortRecursive(numbers, pivot + 1, right);
                }
            }
        }
    }
}
