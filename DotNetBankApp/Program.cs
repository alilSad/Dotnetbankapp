using System;

namespace DotNetBankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //login screen 

            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|        Welcome to Simple Banking         |");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|                Login here:               |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|       Username:                          |");
            Console.WriteLine("|       Password:                          |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|------------------------------------------|");

            Console.SetCursorPosition(18, 6);
            string unInput = Console.ReadLine();
            Console.SetCursorPosition(18, 7);
            string passInput = Console.ReadLine();
            
            try {
                string[] lines = System.IO.File.ReadAllLines("login.txt");

                foreach (string set in lines) {
                    string[] splits = set.Split('|');

                    // splits [0] will be username and splits[1] should be password
                    // call with {0} and {1}
                    // somehow i need to check user input against each line, the foreach loop should do this. please do asap me ;-;
                    //if no match display eeror message
                
                }
            
            
            }

            catch { }



        }
    }
}
