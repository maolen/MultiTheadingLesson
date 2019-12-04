using System;
using System.Threading;

namespace MultiTheadingLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentThread = Thread.CurrentThread;
            //Console.WriteLine($"{currentThread.ManagedThreadId} - айди потока");
            Console.WriteLine($"Поток {currentThread.ManagedThreadId} начал работу");

            //// Имитация длительной работы.
            //Thread.Sleep(5000);

            var thread = new Thread(ProcessWork);
            thread.Start();

            ProcessWork();

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} закончил работу");
            Console.ReadLine();
        }

        static void ProcessWork()
        {
            var currentThread = Thread.CurrentThread;

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{currentThread.ManagedThreadId}] - {i}");
                Thread.Sleep(500);
            }
        }
    }
}
