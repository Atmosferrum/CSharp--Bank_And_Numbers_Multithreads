using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberCounter
{
    class Program
    {
        private static int result = 0;
        private static int start = 1_000_000_000;
        private static int end = 2_000_000_000;
        //private static int counter = 0;
        private static int theNumber;
        private static int numberOfProcessors;

        private static DateTime now;

        //static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {           
            now = DateTime.Now;

            #region Simple Tasks;

            //var t1 = Task.Run(() => CountNumbers(1_000_000_000, 1_250_000_000));
            //var t2 = Task.Run(() => CountNumbers(1_250_000_000, 1_500_000_000));
            //var t3 = Task.Run(() => CountNumbers(1_500_000_000, 1_750_000_000));
            //var t4 = Task.Run(() => CountNumbers(1_750_000_000, 2_000_000_000));

            //Task t1 = Task.Factory.StartNew(Sum, 1_000_000_000);
            //Task<int> t2 = Task<int>.Factory.StartNew(Sum, 1_125_000_000);
            //Task<int> t3 = Task<int>.Factory.StartNew(Sum, 1_250_000_000);
            //Task<int> t4 = Task<int>.Factory.StartNew(Sum, 1_375_000_000);
            //Task<int> t5 = Task<int>.Factory.StartNew(Sum, 1_500_000_000);
            //Task<int> t6 = Task<int>.Factory.StartNew(Sum, 1_625_000_000);
            //Task<int> t7 = Task<int>.Factory.StartNew(Sum, 1_750_000_000);
            //Task<int> t8 = Task<int>.Factory.StartNew(Sum, 1_875_000_000);



            Console.WriteLine($"Processors : {Environment.ProcessorCount}");

            numberOfProcessors = Environment.ProcessorCount;

            theNumber = (end - start) / theNumber;

            Task[] allAvailableTasks = new Task[numberOfProcessors];

            for (int i = 0; i < numberOfProcessors; i++)
            {
                allAvailableTasks[i] = Task.Factory.StartNew(Sum, i);
            }

            //Task.WhenAll(allAvailableTasks[0], allAvailableTasks[7]);

            Task.WaitAll(allAvailableTasks);

            //allAvailableTasks[0].Wait();
            //allAvailableTasks[1].Wait();
            //allAvailableTasks[2].Wait();
            //allAvailableTasks[3].Wait();
            //allAvailableTasks[4].Wait();
            //allAvailableTasks[5].Wait();
            //allAvailableTasks[6].Wait();
            //allAvailableTasks[7].Wait();

            //t1.Wait();
            //t2.Wait();
            //t3.Wait();
            //t4.Wait();

            //Console.WriteLine(t1.Result + t2.Result + t3.Result + t4.Result = t5.Result + t6.Result + t7.Result + t8.Result);

            #endregion Simple Tasks

            #region 1000Tasks;

            //Task[] alltasks = new Task[1000];

            //Action a = new Action(Sum);

            //for (int i = 0; i < 1000; i++)
            //{
            //    alltasks[i] = Task.Factory.StartNew(Sum);
            //    counter++;
            //    Console.WriteLine(counter);
            //}

            //for (int i = 0; i < alltasks.Length; i++)
            //{
            //    if (alltasks[i] != null)
            //        alltasks[i].Wait();
            //}

            #endregion 1000Tasks

            #region ThreadPool;

            ////GetThreadPoolData();

            ////for (int i = 0; i < 1000; i++)
            ////{
            ////    ThreadPool.QueueUserWorkItem(new WaitCallback(Sum));
            ////    counter++;
            ////}

            //manualResetEvent.WaitOne();

            #endregion ThreadPool

            #region Tester

            //CountNumbers(1_000_000_000, 2_000_000_000);

            #endregion Tester

            Console.WriteLine(result);
            Console.WriteLine($" Total time is :{(DateTime.Now - now).TotalSeconds} !!!");

            Console.ReadKey();
        }

        //static void Sum(object o)
        //{
        //    Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");

        //    for (int i = 1_000_000_000 + (1_000_000 * counter); i < 1_000_000_000 + (1_000_000 * (counter + 1)); i++)
        //    {

        //        int[] numbers = new int[10];

        //        int number = i;

        //        int tempIntSum = 0;

        //        for (int j = 0; j < numbers.Length; j++)
        //        {
        //            numbers[j] = number % 10;
        //            number /= 10;
        //            tempIntSum += numbers[j];
        //        }

        //        if (numbers[0] != 0)
        //            if (tempIntSum % numbers[0] == 0)
        //                ++result;
        //    }

        //    Console.WriteLine($"{result}");

        //    Console.WriteLine($"{(DateTime.Now - now).TotalSeconds}");

        //    if (counter == 1000)
        //        manualResetEvent.Set();
        //}
        static void Sum(object o)
        {
            Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");

            for (int i = start + (theNumber * (int)o); i < start + (theNumber * ((int)o + 1)); i++)
            {

                int[] numbers = new int[10];

                int number = i;

                int tempIntSum = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    numbers[j] = number % 10;
                    number /= 10;
                    tempIntSum += numbers[j];
                }

                if (numbers[0] != 0)
                    if (tempIntSum % numbers[0] == 0)
                        ++result;
            }

            Console.WriteLine($"{result}");

            Console.WriteLine($"{(DateTime.Now - now).TotalSeconds}");
        }


        //static void CountNumbers(int start, int end)
        //{
        //    for (int i = start; i < end; i++)
        //    {
        //        int[] numbers = new int[7];

        //        int number = i;

        //        int lastNumber = numbers[0];
        //        int tempIntSum = 0;

        //        for (int j = 0; j < numbers.Length; j++)
        //        {
        //            numbers[j] = number % 10;
        //            number /= 10;
        //            tempIntSum += numbers[j];
        //        }


        //        if (numbers[0] != 0)
        //            if (tempIntSum % numbers[0] == 0)
        //                ++result;
        //    }
        //}

        static void CountNumbers(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                int[] numbers = new int[10];

                int number = i;

                int lastNumber = numbers[0];
                int tempIntSum = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    numbers[j] = number % 10;
                    number /= 10;
                    tempIntSum += numbers[j];
                }
                   

                if (numbers[0] != 0)
                    if (tempIntSum % numbers[0] == 0)
                        ++result;
            }
        }

        private static void GetThreadPoolData()
        {
            int workerThreadsIn, completionThreads;

            ThreadPool.GetAvailableThreads(out workerThreadsIn, out completionThreads);

            int maxWorkerThreadsIn, maxCompletionThreads;

            Console.WriteLine($"Availabmle threads : {workerThreadsIn} + {completionThreads}");

            ThreadPool.GetMaxThreads(out maxWorkerThreadsIn, out maxCompletionThreads);

            Console.WriteLine($"Max threads : {maxWorkerThreadsIn} + {maxCompletionThreads}");
        }
    }

   
}
