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
        private static int start;
        private static int end;
        private static int counter = 0;
        private static int theNumber;

        private static DateTime now;

        static void Main(string[] args)
        {
            now = DateTime.Now;

            Console.WriteLine(now);


            #region Simple Tasks;

            //var t1 = Task.Run(() => CountNumbers(1_000_000, 1_250_000));
            //var t2 = Task.Run(() => CountNumbers(1_250_000, 1_500_000));
            //var t3 = Task.Run(() => CountNumbers(1_500_000, 1_750_000));
            //var t4 = Task.Run(() => CountNumbers(1_750_000, 2_000_000));

            //Task<int> t1 = Task<int>.Factory.StartNew(Sum, 1_000_000_000);
            //Task<int> t2 = Task<int>.Factory.StartNew(Sum, 1_125_000_000);
            //Task<int> t3 = Task<int>.Factory.StartNew(Sum, 1_250_000_000);
            //Task<int> t4 = Task<int>.Factory.StartNew(Sum, 1_375_000_000);            
            //Task<int> t5 = Task<int>.Factory.StartNew(Sum, 1_500_000_000);
            //Task<int> t6 = Task<int>.Factory.StartNew(Sum, 1_625_000_000);
            //Task<int> t7 = Task<int>.Factory.StartNew(Sum, 1_750_000_000);
            //Task<int> t8 = Task<int>.Factory.StartNew(Sum, 1_875_000_000);            

            //t1.Wait();
            //t2.Wait();
            //t3.Wait();
            //t4.Wait();
            //t5.Wait();
            //t6.Wait();
            //t7.Wait();
            //t8.Wait(); 

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

            GetThreadPoolData();

            for (int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Sum));
                counter++;
            }

            #endregion ThreadPool

            //CountNumbers(1_000_000, 2_000_000);

            Console.WriteLine(result);            

            Console.ReadKey();
        }

        static void Sum(object o)
        {
            Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 1_000_000_000 + (1_000_000 * counter); i < 1_000_000_000 + (1_000_000 * (counter + 1)); i++)
            {
                char[] tempCharArray = Convert.ToString(i).ToCharArray();
                int lastNumber = i % 10;
                int tempIntSum = 0;

                for (int j = 0; j < tempCharArray.Length; j++)
                    tempIntSum += Convert.ToInt32(tempCharArray[j]);

                if (lastNumber != 0)
                    if (tempIntSum % lastNumber == 0)
                        ++result;
            }

            Console.WriteLine($"{result}");

            Console.WriteLine($"{(DateTime.Now - now).TotalSeconds}");
        }

        static void CountNumbers(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                char[] tempCharArray = Convert.ToString(i).ToCharArray();
                int lastNumber = i % 10;
                int tempIntSum = 0;

                for (int j = 0; j < tempCharArray.Length; j++)
                    tempIntSum += Convert.ToInt32(tempCharArray[j]);

                if (i % 10 != 0)
                    if (tempIntSum % lastNumber == 0)
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
