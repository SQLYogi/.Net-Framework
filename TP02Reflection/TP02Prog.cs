using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;

namespace TP02Reflection
{
    class TP02Prog
    {
        static void Main(string[] args)
        {

            string path = @"F:\Digicomp2016\FrameworkDotNet\TP01Configuration\bin\Debug\TP01Configuration.exe";

            //Load an assembly from a file
            Assembly assembly = Assembly.LoadFile(path);
            
            //assembly modules
            foreach (var module in assembly.Modules)
                WriteLine($"module {module.Name}");
            
            //assembly types
            foreach (Type type in assembly.GetTypes())
                WriteLine($"Type: {type.FullName}");

            //Récupère la Class program
            var tp01 = assembly.GetType("TP01Configuration.TP01Prog");
            //en créé une instance
            var instance = assembly.CreateInstance("TP01Configuration.TP01Prog");
            //Récupère une référence à la méthod
            var methodInfo = tp01.GetMethod("GetUserFavoriteColor");
            //Appel la méthode 
            WriteLine($"Method invocation:{methodInfo.Invoke(instance, null)}");


            //With dynamics, That's more easier!!!
            //NB: Class, Méthods and Properties must be public
            dynamic dynInstance = assembly.CreateInstance("TP01Configuration.TP01Prog");
            WriteLine($"From Dynamic : {dynInstance.GetUserFavoriteColor()}");
            
            //Wait until key pressed
            ReadKey();

        }
    }


  
}
