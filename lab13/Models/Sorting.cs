using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab13.Models
{
    public class Sorting
    {

        public int[] arr { get; set; } = { 1, 14, 47, 96, 45, 6, 18, 3, 25, 30, 12, 10, 36, 48, 5, 17 };

         int threadsCountBubble = 4;
         int threadsCountShell = 8;

        public double effectivityAnalisys { get; set; }
        public double effectivityAnalisys2 { get; set; }

        Stopwatch sw = new Stopwatch();

        Task[] tasks;
        public Sorting()
        {
            sw.Start();
        }
        //===============Bubble=======================
        public void BubbleSort()
        {
            tasks = new Task[threadsCountBubble];

            int counter = 0;
            sw.Stop();
            Stopwatch swMain = new Stopwatch();
            swMain.Start();
            while (counter != arr.Length - 1)
            {
                for (int i = 0; i < threadsCountBubble; i++)
                {
                    tasks[i] = new Task(() => bubbleSortCycle(i));
                    tasks[i].Start();
                    counter++;
                    if (counter == arr.Length - 1)
                    {
                        break;
                    }
                }
                Task.WaitAll(tasks);
            }
            swMain.Stop();

            double n_div_p = arr.Length / threadsCountBubble;
            effectivityAnalisys = ((n_div_p) * Math.Log2(n_div_p) + 2 * arr.Length) * swMain.ElapsedMilliseconds + threadsCountBubble * (sw.ElapsedMilliseconds + sizeof(int) * (n_div_p) / 1);
        }
        private void bubbleSortCycle(int i)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
        }
        //===============Shell=======================

        int shellCounter = 0;
        public void ShellSort()
        {
            tasks = new Task[threadsCountShell];

            var d = arr.Length / 2;

            sw.Stop();
            Stopwatch swMain = new Stopwatch();
            swMain.Start();

            while (d >= 1)
            {
                for (int i = 0; i < threadsCountShell; i++)
                {
                    tasks[i] = new Task(() => shellSortCycle(d));
                    tasks[i].Start();
                }
                Task.WaitAll(tasks);
                d = d / 2;
            }
            swMain.Stop();
            double n_div_p = arr.Length / threadsCountShell;
            effectivityAnalisys = (n_div_p) * Math.Log2(n_div_p) * swMain.ElapsedMilliseconds +
                (Math.Log2(threadsCountShell) + shellCounter) * ((2 * n_div_p) * sw.ElapsedMilliseconds +
                sw.ElapsedMilliseconds + sizeof(int) * (n_div_p) / 1);

        }
        private void shellSortCycle(int d)
        {
            for (var i = d; i < arr.Length; i++)
            {
                var j = i;
                while ((j >= d) && (arr[j - d] > arr[j]))
                {
                    shellCounter++;
                    var temp = arr[j];
                    arr[j] = arr[j - d];
                    arr[j - d] = temp;
                    j = j - d;
                }
            }
        }
        //=================Change threads count=====================
        public void SwapThreadsCount()
        {
            var temp = threadsCountBubble;
            threadsCountBubble = threadsCountShell;
            threadsCountShell = temp;
        }
    }
}
