using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TP04Multithreading
{
    class TP04Prog
    {
        static Stopwatch st = new Stopwatch();
        static  void Main(string[] args)
        {

            //var currentProcess =Process.GetCurrentProcess();
            Action<string> W = (x) =>  WriteLine(x);
            st.Restart();
            
            Thread thread1 = new Thread(()=> DoSomething("Thread1"));
            Thread thread2 = new Thread(() => DoSomething("Thread2"));
            Task task1 = new Task(() => DoSomething("Task1"));
            Task task2 = new Task(() => DoSomething("Task2"));
            
            thread1.Start();
            thread2.Start();
            task1.Start();
            task2.Start();                       

            thread1.Join();
            thread2.Join();            
            task1.Wait();
            task2.Wait();
            StopAndWriteElapseTime("Finish Tasks and Threads");

            st.Restart();
            Parallel.Invoke(() => DoSomething("parall1")
            , () => DoSomething("parall2")
            , () => DoSomething("parall3")
            , () => DoSomething("parall4")
            );
            StopAndWriteElapseTime("Finish Parallel");

            ReadKey();
        }

        private static void DoSomething(string caller )
        {
           
            WriteLine($"Starting {caller},Tread ID { Thread.CurrentThread.ManagedThreadId.ToString().PadRight(3)}");
            for (int i = 0; i <2; i++)
            {
                Thread.Sleep(20);
                WriteLine($"{caller.PadRight(8)},iteration {i}");
            }
        }

       
      

        private static void StopAndWriteElapseTime(string log)
        {
            st.Stop();
            WriteLine($"{log}:{st.ElapsedMilliseconds}ms");
        }


    }
}
