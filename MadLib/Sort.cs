namespace MadLib
{
    public static class Sort
    {
        public static int[] BubbleSort(this int[] arr)
        {
            int sorted;
            do
            {
                sorted = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Tools.Swap(ref arr[i], ref arr[i + 1]);
                        sorted++;
                    }
                }
            } while (sorted != 0);

            return arr;
        }

        public static int[] QuickSort(this int[] array)
        {
            var arr = array.DeepClone();
            QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static int QuickSort(int[] pole, int left, int right, int pivot)
        {
            pole.SwapIndexInArray(pivot, right);
            int index = left;
            for (int i = left; i < right; i++)
            {
                if (pole[i] < pole[right])
                {
                    pole.SwapIndexInArray(i, index);
                    index++;
                }
            }
            pole.SwapIndexInArray(right, index);
            return index;
        }

        static void QuickSort(int[] pole, int left, int right)
        {
            if (right >= left)
            {
                int pivot = left;
                int newPivot = QuickSort(pole, left, right, pivot);
                QuickSort(pole, left, newPivot - 1);
                QuickSort(pole, newPivot + 1, right);
            }
        }
    }
}
