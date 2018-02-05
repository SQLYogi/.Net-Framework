using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TP04Multithreading
{

    
    class TP04Prog
    {
        //L'objet Stopwatch nous permet de compter le temps écoulé
        static Stopwatch st = new Stopwatch();

        static  void Main(string[] args)
        {
           
            //Démarre le compteur
            st.Restart();

            //Créé 2 Threads qui exécutent la fonction DoSomething
            Thread thread1 = new Thread(() => { DoSomethingLong("Thread1"); });
            Thread thread2 = new Thread(() => DoSomethingLong("Thread2"));

            //Créé 2 Tasks qui exécutent la fonction DoSomething
            Task task1 = new Task(() => DoSomethingLong("Task1"));
            Task task2 = new Task(() => DoSomethingLong("Task2"));
            
            //Démarre les Threads et les Tasks
            thread1.Start();
            thread2.Start();
            task1.Start();
            task2.Start();


            //attend que tout soit terminé
            thread1.Join();
            thread2.Join();            
            task1.Wait();
            task2.Wait();

            //Affiche le temps écoulé
            StopAndWriteElapseTime("Finish Tasks and Threads");

            //Relance le compteur
            st.Restart();
            //Exécute les actions en parallèle
            Parallel.Invoke(() => DoSomethingLong("parall1")
            , () => DoSomethingLong("parall2")
            , () => DoSomethingLong("parall3")
            , () => DoSomethingLong("parall4")
            );
            //Affiche le temps écoulé
            StopAndWriteElapseTime("Finish Parallel");

            WriteLine("Press any key to quit...");           
            ReadKey();
        }


        private async static void DoSomethingLong(string caller )
        {                                 
            for (int i = 0; i < 10; i++)
                {                   
                    WriteLine($"{caller.PadRight(10)},iteration {i}");
                   // Thread.Sleep(0);
                     await Task.Run(()=>Thread.Sleep(1000));
            }
              
        }


        private static void StopAndWriteElapseTime(string log)
        {
            st.Stop();
            WriteLine($"{log}:{st.ElapsedMilliseconds}ms");
        }


    }
}
