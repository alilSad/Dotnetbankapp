using System;
using System.IO;

namespace DotNetBankApp
{
    class Program
    {
        public static string unInput;
        public static string passInput;
        //when you log out remeber to set it back to false!
        public static Boolean correctDeet = false;




        static void Login() {

            try
            {
                string[] lines = File.ReadAllLines("login.txt");

                foreach (string set in lines)
                {
                    string[] splits = set.Split('|');

                    //tester dw
                    //Console.WriteLine("{0}{1}", splits[0], splits[1]);

                    if (splits[0] == unInput && splits[1] == passInput)
                    {
                        correctDeet = true;
                        
                    }

                    else {

                       //this is probably not the best way to do it?
                    
                    }


                }

                if (correctDeet)
                {
                    Console.WriteLine("Welcome {0}!", unInput);

                }
                else {
                    Console.WriteLine("Invalid details, please try again");


                }


            }

            catch(FileNotFoundException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please press any key to exit application. Contact administrator for support.");
                Console.ReadKey();
            
            }

        }
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
            unInput = Console.ReadLine();
            Console.SetCursorPosition(18, 7);
            passInput = Console.ReadLine();
            Console.SetCursorPosition(3, 8);

            Login();
            



        }

  


    }
}
