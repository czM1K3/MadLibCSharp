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
                        Tools.SwapInt(ref arr[i], ref arr[i + 1]);
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
            SwapInArray(pole, pivot, right);
            int index = left;
            for (int i = left; i < right; i++)
            {
                if (pole[i] < pole[right])
                {
                    SwapInArray(pole, i, index);
                    index++;
                }
            }
            SwapInArray(pole, right, index);
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

        static void SwapInArray(int[] arr, int i1, int i2)
        {
            int help = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = help;
        }
    }
}
