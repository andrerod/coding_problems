namespace CodingProblems
{
    public class MergeSort
    {
        public void DoMerge(int[] array, int left, int mid, int right)
        {
            int leftEnd = mid - 1;
            int tmpPos = left;
            int numElements = (right - left + 1);

            int[] temp = new int[numElements];

            while ((left <= leftEnd) || (mid <= right))
            {
                if (array[left] <= array[mid])
                {
                    temp[tmpPos++] = array[left++];
                }
                else
                {
                    temp[tmpPos++] = array[mid++];
                }
            }

            while (left <= leftEnd)
            {
                temp[tmpPos++] = array[left++];
            }

            while (mid <= right)
            {
                temp[tmpPos++] = array[mid++];
            }

            for (int i = 0; i < numElements; i++)
            {
                array[right--] = temp[tmpPos--];
            }
        }

        public void DoMergeSort(int[] array, int left, int right)
        {
            int mid;

            if (left < right)
            {
                mid = (left + right) / 2;
                DoMergeSort(array, left, mid);
                DoMergeSort(array, mid + 1, right);

                DoMerge(array, left, (mid + 1), right);
            }
        }

        public void Merge(int[] array)
        {
            DoMergeSort(array, 0, array.Length - 1);
        }
    }
}
