using System;
using System.IO;

namespace DotNetBankApp
{
    class Program
    {
        
        public static string unInput;
        public static string passInput;
        public static Boolean correctDeet = false;
        public static string temp = "";
        

        static void enterDetails()
        {

            

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("        Welcome to Simple Banking         ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("                                          ");
            Console.WriteLine("                Login here:               ");
            Console.WriteLine("                                          ");
            Console.WriteLine("       Username:                          ");
            Console.WriteLine("       Password:                          ");
            Console.WriteLine("                                          ");
            Console.WriteLine("------------------------------------------");


            Console.SetCursorPosition(18, 6);
            unInput = Console.ReadLine();
            Console.SetCursorPosition(18, 7);
            // passInput = Console.ReadLine();
            
            CheckPassword(temp);

           Login();



        }

        static void CheckPassword(string EnterText)
        {
            
            try
            {
                
                Console.Write(EnterText);
                passInput = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work  
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        passInput += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && passInput.Length > 0)
                        {
                            passInput = passInput.Substring(0, (passInput.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            
                                break;
                            
                        }
                    }
                } while (true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        static void Login() {

            // read through the usernames and passwords in the text file. if credentials correct let the user log in, and invalid ones let them try again. 

            try
            {
                string[] lines = File.ReadAllLines("login.txt");

                foreach (string set in lines)
                {
                    string[] splits = set.Split('|');


                    if (splits[0] == unInput && splits[1] == passInput)
                    {
                        correctDeet = true;
                        
                    }

                }

                if (correctDeet)
                {
                    Console.WriteLine("\nWelcome {0}! Press any button to continue!", unInput);
                    Console.ReadKey();
                    Console.Clear();
                    AccountClass.MainMenu();



                }
                else {
                    Console.WriteLine("\nInvalid details, press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    enterDetails();

                    

                }


            }

            //cant find file error
            catch(FileNotFoundException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please press any key to exit application. Contact administrator for support.");
                Console.ReadKey();
            
            }

        }
        static void Main(string[] args)
        {

            //login screen 

            enterDetails();


        }

  


    }
}
