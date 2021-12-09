using System;
using System.Collections;

namespace SortRyabov
{
    public class Program
    {
        private static void Main()
        {
        }

        public static void Swap(ref int v1, ref int v2)
        {
            var buf = v1;
            v1 = v2;
            v2 = buf;
        }
    }

    public class QuickSort
    {
        public void Sort(int[] arr)
        {
            var i = 0;
            var j = 0;
            var stack = new Stack();

            stack.Push(arr.Length - 1);
            stack.Push(0);
            do
            {
                var left = (int) stack.Pop();
                var right = (int) stack.Pop();
                if (((right - left) == 1) && (arr[left] > arr[right]))
                    Program.Swap(ref arr[left], ref arr[right]);
                else
                {
                    var median = arr[(left + right) / 2];
                    i = left;
                    j = right;
                    do
                    {
                        while ((median > arr[i]))
                            ++i;
                        while (arr[j] > median)
                            --j;
                        if (i < j)
                        {
                            Program.Swap(ref arr[i], ref arr[j]);
                            ++i;
                            --j;
                        }
                        else if(i == j)
                        {
                            ++i;
                            --j;
                        }
                    } while (i <= j);
                }

                if (left < j)
                {
                    stack.Push(j);
                    stack.Push(left);
                }

                if (i >= right) continue;
                stack.Push(right);
                stack.Push(i);
            } while (stack.Count != 0);
        }
    }

    public class PyramidSort
    {
        private static int AddToPyramid(int[] arr, int i, int len)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));

            var maxI = ((2 * i) + 2) < len
                ? (arr[(2 * i) + 1] < arr[(2 * i) + 2] ? (2 * i) + 2 : (2 * i) + 1)
                : (2 * i) + 1;

            if (maxI >= len) return i;

            if (arr[i] >= arr[maxI]) return i;

            Program.Swap(ref arr[i], ref arr[maxI]);
            if (maxI < len / 2) i = maxI;
            return i;
        }

        public void Sort(int[] arr)
        {
            var len = arr.Length;

            if (arr == null) throw new ArgumentNullException(nameof(arr));

            for (var i = (len / 2) - 1; i >= 0; --i)
            {
                var prevI = i;
                i = AddToPyramid(arr, i, len);
                if (prevI != i) ++i;
            }

            for (var k = len - 1; k > 0; --k)
            {
                Program.Swap(ref arr[0], ref arr[k]);
                int i = 0, prevI = -1;
                while (i != prevI)
                {
                    prevI = i;
                    i = AddToPyramid(arr, i, k);
                }
            }
        }
    }

    public class ShellSort
    {
        public void Sort(int[] arr, int step, Func<int> func)
        {
            while (step > 0)
            {
                for (var i = step; i < arr.Length; i++)
                {
                    var value = arr[i];
                    int j;
                    for (j = i - step; (j >= 0) && (arr[j] > value); j -= step)
                        arr[j + step] = arr[j];
                    arr[j + step] = value;
                }

                step = func();
            }
        }
    }
}