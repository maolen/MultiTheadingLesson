using System;
using System.Collections.Generic;
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

            //var thread = new Thread(ProcessWork);
            ////блокирует вызывающий поток пока не завершит работу
            // thread.Join();
            //thread.IsBackground = false;
            //thread.Priority - никогда не используется
            //thread.Start();
            var thread = new Thread(ProcessData);
            thread.Start(new List<object> 
            {
                new {Name = "Bob"},
                new {Name = "Alice"}
            });
            //ProcessWork();

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} закончил работу");
            //Console.ReadLine();
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

        static void ProcessData(object data)
        {
            Thread.Sleep(3000);
            foreach(var item in data as List<object>)
            {
                Console.WriteLine(item);
            }
        }
    }
}
