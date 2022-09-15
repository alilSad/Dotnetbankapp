using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetBankApp
{
    class AccountClass
    {

        public static int menuOption;

        string firstName;
        string lastName;
        string address;
        string phone;
        string email;







        public static void MainMenu() {

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("        Welcome to Simple Banking         ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" 1: Create a new account                  ");
            Console.WriteLine(" 2: Search for an account                 ");
            Console.WriteLine(" 3: Deposit                               ");
            Console.WriteLine(" 4: Withdraw                              ");
            Console.WriteLine(" 5: A/C Statement                         ");
            Console.WriteLine(" 6: Delete Account                        ");
            Console.WriteLine(" 7: Exit                                  ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Enter a number 1-7:                      ");
            Console.WriteLine("------------------------------------------");

            Console.SetCursorPosition(21, 11);
            validateSelection();




        }

        static void validateSelection(){

            //this tests to see if the input is an integer, and then makes sure its actually between 1-7
            //also gives user an error message 
            while (!int.TryParse(Console.ReadLine(), out menuOption)) {
                Console.SetCursorPosition(2, 13);
                Console.WriteLine("Invalid input, press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }

            if (menuOption > 0 && menuOption < 8) {
                selector();

            } else {

                Console.SetCursorPosition(2, 13);
                Console.WriteLine("Invalid input, press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
            
        }

        static void selector() {

            switch (menuOption){

                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;


            }


            Console.SetCursorPosition(2, 13);


        
        
        }
    }
}
