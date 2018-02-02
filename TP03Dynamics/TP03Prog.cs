using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Dynamic;
using static System.Console;
using System.Threading;
using System.ComponentModel;

namespace TP03Dynamics
{
    class TP03Prog
    {
        delegate string functionReference(string param1);

        static void Main(string[] args)
        {
            var x = 1;
            dynamic y = 1;

            //x = "As string now";
            y = "As string now";

            WriteLine(x.GetType());
            WriteLine(y.GetType());

            //As an object now, we can call methods and Properties
            y = new Dog();
            WriteLine($"J'ai {y.NLegs} pattes");
            WriteLine(y.Aboye("Je suis un chien!"));

            //As a function delegate           
            y = new functionReference(WriteSomething); ;
            WriteLine(y("Je suis une fonction!"));

            //As an Action
            y = new Action<string>(str1 => WriteLine($"Je suis une Action {str1}"));
            y("Coool!");
            //As a Func
            y = new Func<string, string>(str1 => $"Je suis Func {str1}!");
            WriteLine(y("Funcky"));

            //As an asynchronious task
            y = new Task(() =>
            {
                WriteLine("Je suis une tache asynchrone!!");
                Thread.Sleep(3000);
                WriteLine("J'ai fini mon travail asynchrone, je travail dur!");
            });
            y.Start();
            WriteLine("La tache asynchrone fait son boulot, moi je suis libre!");

            //A dynamic ExpandoObject
            dynamic expandObject = new ExpandoObject();
            expandObject.FirstName = "Nicolas";
            expandObject.LastName = "Bonin";
            expandObject.Greating = new Func<string,string>(param1=>$"Hello from Expando my friend {param1}");
            WriteLine(expandObject.Greating(expandObject.FirstName));

            //Add an event Handler
            expandObject.MyEvent = null;
            expandObject.MyEvent += new EventHandler(OnMyEvent);
            //Call the event if it has a least on ref
            expandObject.MyEvent?.Invoke(expandObject,new EventArgs());

            //require  System.ComponentModel;
            ((INotifyPropertyChanged)expandObject).PropertyChanged += TP03Prog_PropertyChanged;
            expandObject.FirstName = "Tutu";
            expandObject.LastName = "Toto";                    
            
            ReadKey();
        }

        private static void OnMyEvent(object sender, EventArgs e)
        {
            WriteLine($"Event Handler called by {sender}");
        }

        private static void TP03Prog_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WriteLine($"Property change on {e.PropertyName}");
        }

        public static string WriteSomething(string what) => $"WriteSomething:{what}";
    }

    class Dog
    {
        public int NLegs { get; set; } = 4;
        public string Aboye(string something) => $"WOUF WOUF:{something}";
    }
}
