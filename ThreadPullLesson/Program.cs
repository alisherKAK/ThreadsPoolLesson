using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPullLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var threads = new Thread[20];
            for(int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(Print);
            }

            foreach(var thread in threads)
            {
                thread.Start();
            }*/

            //for (int i = 0; i < 20; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(Print);
            //}

            Timer timer = new Timer(PrintTime, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));

            Console.ReadLine();
            timer.Dispose();
        }

        static void PrintTime(object state)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
        }

        static void Print(object state)
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Поток номер {currentThread.ManagedThreadId} начал работать");

            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(5 * new Random().Next(100));
                Console.Write(i + " ");
            }

            Console.WriteLine($"\nПоток номер {currentThread.ManagedThreadId} закончал работать");
        }
    }
}
