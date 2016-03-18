using Newtonsoft.Json;
using SEDC.AdvancedLinqSetup.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AdvancedLinqSetup
{


    class Program
    {
        static void Main()
        {
            Utils.InitData();

            Console.ReadLine();
            var x = DataContext.Users;

            Console.ReadLine();
        }

      
        

    }
}
