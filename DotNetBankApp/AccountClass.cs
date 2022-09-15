using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetBankApp
{
    class AccountClass
    {

        public static int menuOption;
        public static int number;

        public static string firstName;
        public static string lastName;
        public static string address;
        public static string phone;
        public static string email;

        public static int accountNumber;

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

        static void validateSelection() {

            //this tests to see if the input is an integer, and then makes sure its actually between 1-7
            //also gives user an error message 
            if (!int.TryParse(Console.ReadLine(), out menuOption)) {
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
            Console.Clear();
            switch (menuOption) {

                case 1:
                    Option1();
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

        }

        //Create new account

        static void Option1() {

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("            Create a new Account             ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("       Enter customer details below:         ");
            Console.WriteLine("                                             ");
            Console.WriteLine("First name:                                  ");
            Console.WriteLine("Last name:                                   ");
            Console.WriteLine("Address:                                     ");
            Console.WriteLine("Phone number:                                ");
            Console.WriteLine("Email:                                       ");
            Console.WriteLine("---------------------------------------------");

            Console.SetCursorPosition(12, 5);
            firstName = Console.ReadLine();
            Console.SetCursorPosition(11, 6);
            lastName = Console.ReadLine();
            Console.SetCursorPosition(9, 7);
            address = Console.ReadLine();
            Console.SetCursorPosition(14, 8);
            phone = Console.ReadLine();
            Console.SetCursorPosition(7, 9);
            email = Console.ReadLine();

            

            Console.SetCursorPosition(0, 11);

            // check phone and email
            if (!int.TryParse(phone, out number))
            {
                Console.WriteLine("Please put a proper phone number.");
                Console.ReadKey();
                Console.Clear();
                Option1();


            }
            else if (phone.Length != 10)
            {
                Console.WriteLine("Please put a proper phone number.");
                Console.ReadKey();
                Console.Clear();
                Option1();

            }

            if (!validEmail()) {
                Console.WriteLine("Please put a valid email.");
                Console.ReadKey();
                Console.Clear();
                Option1();
            
            }

            //check if the info is correct? 

            Option1Confirm();

            Console.WriteLine("Account created. Details will be provided via email");
            Console.WriteLine("Account number is: ");

        }


        // email checker
        public static bool validEmail() {
            var trimEmail = email.Trim();
            if (trimEmail.EndsWith(".")) {
                return false;
            
            }

            try
            {
                var checkAdd = new System.Net.Mail.MailAddress(email);
                return checkAdd.Address == trimEmail;

            }

            catch {
                return false;
            
            }
           

        
        }


        public static void Option1Confirm() {
            accountNumber = 100000;

            var accountString = Convert.ToString(accountNumber);
            

            // if (!File.Exists(accountString,".txt")) {
            
            
            
            //}

        
        }



        }



    }



