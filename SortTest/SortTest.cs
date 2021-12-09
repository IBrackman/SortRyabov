using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortRyabov;
using static System.Math;

namespace SortTest
{
    [TestClass]
    public class PyramidSortTest
    {
        [TestMethod]
        public void Test()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);
            
            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var a = DateTime.Now.Ticks;

            new PyramidSort().Sort(arr);

            Console.Write(DateTime.Now.Ticks - a);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }
    }

    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestQR()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var b = DateTime.Now.Ticks;

            new QuickSort().Sort(arr);

            Console.Write(DateTime.Now.Ticks - b);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }
    }

    [TestClass]
    public class ShellSortTest
    {
        [TestMethod]
        public void Test1I()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var stepCounter = 1;

            int StepChange() => (int)(arr.Length / Pow(2, stepCounter++));

            new ShellSort().Sort(arr, arr.Length / 2, StepChange);

            stepCounter = 1;

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, arr.Length / 2, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test2I()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var deg = 0;

            while ((int)(Pow(2, deg + 1) - 1) <= arr.Length) deg++;

            int StepChange() => (int)(Pow(2, deg--) - 1);

            var buf = deg;

            new ShellSort().Sort(arr, (int)(Pow(2, deg--) - 1), StepChange);

            deg = buf;

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, (int)(Pow(2, deg--) - 1), StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test3I()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var deg = 0;

            while (((int)((9 * Pow(2, deg + 1)) - (9 * Pow(2, (deg + 1) / 2)) + 1) <= arr.Length / 3) &&
                   (((int)((8 * Pow(2, deg + 1)) - (6 * Pow(2, (deg + 2) / 2)) + 1) <= arr.Length / 3))) deg++;

            int StepChange()
            {
                deg--;

                return (deg + 1) % 2 == 0
                    ? (int)((9 * Pow(2, (deg + 1))) - (9 * Pow(2, (deg + 1) / 2)) + 1)
                    : (int)((8 * Pow(2, (deg + 1))) - (6 * Pow(2, (deg + 2) / 2)) + 1);
            }

            var start = deg % 2 == 0
                ? (int)((9 * Pow(2, deg)) - (9 * Pow(2, deg / 2)) + 1)
                : (int)((8 * Pow(2, deg)) - (6 * Pow(2, (deg + 1) / 2)) + 1);

            var buf = deg;

            new ShellSort().Sort(arr, start, StepChange);

            deg = buf;

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, start, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test4I()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var pratt = new List<int>();

            for (var i = 0; Pow(2, i) <= arr.Length / 2; i++)
                for (var j = 0; Pow(3, j) <= arr.Length / 2; j++)
                    if ((Pow(2, i) * Pow(3, j)) <= arr.Length / 2)
                        pratt.Add((int)(Pow(2, i) * Pow(3, j)));

            pratt.Add(0);

            pratt.Sort();

            var len = pratt.Count - 1;

            int StepChange() => pratt[len--];

            var buf = len;

            new ShellSort().Sort(arr, pratt[len], StepChange);

            len = buf;

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, pratt[len], StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test1D()
        {
            var incrArr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < incrArr.Length; i++) incrArr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(incrArr);

            expected.Sort();

            var stepCounter = 1;

            int StepChange() => (int)(incrArr.Length / Pow(2, stepCounter++));

            new ShellSort().Sort(incrArr, incrArr.Length / 2, StepChange);

            stepCounter = 1;

            var decrArr = new int[10000];

            for (var i = 0; i <= incrArr.Length - 1; i++) decrArr[i] = incrArr[incrArr.Length - 1 - i];

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(decrArr, decrArr.Length / 2, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < decrArr.Length; i++) Assert.AreEqual(decrArr[i], expected[i]);
        }

        [TestMethod]
        public void Test2D()
        {
            var incrArr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < incrArr.Length; i++) incrArr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(incrArr);

            expected.Sort();

            var deg = 0;

            while ((int)(Pow(2, deg + 1) - 1) <= incrArr.Length) deg++;

            int StepChange() => (int)(Pow(2, deg--) - 1);

            var buf = deg;

            new ShellSort().Sort(incrArr, incrArr.Length / 2, StepChange);

            deg = buf;

            var decrArr = new int[10000];

            for (var i = 0; i <= incrArr.Length - 1; i++) decrArr[i] = incrArr[incrArr.Length - 1 - i];

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(decrArr, (int)(Pow(2, deg--) - 1), StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < decrArr.Length; i++) Assert.AreEqual(decrArr[i], expected[i]);
        }

        [TestMethod]
        public void Test3D()
        {
            var incrArr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < incrArr.Length; i++) incrArr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(incrArr);

            expected.Sort();

            var deg = 0;

            while (((int)((9 * Pow(2, deg + 1)) - (9 * Pow(2, (deg + 1) / 2)) + 1) <= incrArr.Length / 3) &&
                   (((int)((8 * Pow(2, deg + 1)) - (6 * Pow(2, (deg + 2) / 2)) + 1) <= incrArr.Length / 3))) deg++;

            int StepChange()
            {
                deg--;

                return (deg + 1) % 2 == 0
                    ? (int)((9 * Pow(2, (deg + 1))) - (9 * Pow(2, (deg + 1) / 2)) + 1)
                    : (int)((8 * Pow(2, (deg + 1))) - (6 * Pow(2, (deg + 2) / 2)) + 1);
            }

            var start = deg % 2 == 0
                ? (int)((9 * Pow(2, deg)) - (9 * Pow(2, deg / 2)) + 1)
                : (int)((8 * Pow(2, deg)) - (6 * Pow(2, (deg + 1) / 2)) + 1);

            var buf = deg;

            new ShellSort().Sort(incrArr, incrArr.Length / 2, StepChange);

            deg = buf;

            var decrArr = new int[10000];

            for (var i = 0; i <= incrArr.Length - 1; i++) decrArr[i] = incrArr[incrArr.Length - 1 - i];

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(decrArr, start, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < decrArr.Length; i++) Assert.AreEqual(decrArr[i], expected[i]);
        }

        [TestMethod]
        public void Test4D()
        {
            var incrArr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < incrArr.Length; i++) incrArr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(incrArr);

            expected.Sort();

            var pratt = new List<int>();

            for (var i = 0; Pow(2, i) <= incrArr.Length / 2; i++)
                for (var j = 0; Pow(3, j) <= incrArr.Length / 2; j++)
                    if ((Pow(2, i) * Pow(3, j)) <= incrArr.Length / 2)
                        pratt.Add((int)(Pow(2, i) * Pow(3, j)));

            pratt.Add(0);

            pratt.Sort();

            var len = pratt.Count - 1;

            int StepChange() => pratt[len--];

            var buf = len;

            new ShellSort().Sort(incrArr, incrArr.Length / 2, StepChange);

            len = buf;

            var decrArr = new int[10000];

            for (var i = 0; i <= incrArr.Length - 1; i++) decrArr[i] = incrArr[incrArr.Length - 1 - i];

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(decrArr, pratt[len], StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < decrArr.Length; i++) Assert.AreEqual(decrArr[i], expected[i]);
        }

        [TestMethod]
        public void Test1R()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var stepCounter = 1;

            int StepChange() => (int) (arr.Length / Pow(2, stepCounter++));

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, arr.Length / 2, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test2R()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var deg = 0;

            while ((int) (Pow(2, deg + 1) - 1) <= arr.Length) deg++;

            int StepChange() => (int) (Pow(2, deg--) - 1);

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, (int)(Pow(2, deg--) - 1), StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test3R()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var deg = 0;

            while (((int) ((9 * Pow(2, deg + 1)) - (9 * Pow(2, (deg + 1) / 2)) + 1) <= arr.Length / 3) &&
                   (((int) ((8 * Pow(2, deg + 1)) - (6 * Pow(2, (deg + 2) / 2)) + 1) <= arr.Length / 3))) deg++;

            int StepChange()
            {
                deg--;

                return (deg + 1) % 2 == 0
                    ? (int) ((9 * Pow(2, (deg + 1))) - (9 * Pow(2, (deg + 1) / 2)) + 1)
                    : (int) ((8 * Pow(2, (deg + 1))) - (6 * Pow(2, (deg + 2) / 2)) + 1);
            }

            var start = deg % 2 == 0
                ? (int)((9 * Pow(2, deg)) - (9 * Pow(2, deg / 2)) + 1)
                : (int)((8 * Pow(2, deg)) - (6 * Pow(2, (deg + 1) / 2)) + 1);

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, start, StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }

        [TestMethod]
        public void Test4R()
        {
            var arr = new int[10000];

            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10000);

            var expected = new List<int>();

            expected.AddRange(arr);

            expected.Sort();

            var pratt = new List<int>();

            for (var i = 0; Pow(2, i) <= arr.Length/2; i++)
            for (var j = 0; Pow(3, j) <= arr.Length/2; j++)
                if ((Pow(2, i) * Pow(3, j)) <= arr.Length/2)
                    pratt.Add((int) (Pow(2, i) * Pow(3, j)));

            pratt.Add(0);

            pratt.Sort();

            var len = pratt.Count - 1;

            int StepChange() => pratt[len--];

            var c = DateTime.Now.Ticks;

            new ShellSort().Sort(arr, pratt[len], StepChange);

            Console.Write(DateTime.Now.Ticks - c);

            for (var i = 0; i < arr.Length; i++) Assert.AreEqual(arr[i], expected[i]);
        }
    }
}