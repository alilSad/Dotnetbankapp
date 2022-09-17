using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Linq;

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
        public static string sendThis;
        

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
    //----------------------------------------------------------------------------------------------------------------
        static void selector() {
            Console.Clear();
            switch (menuOption) {

                case 1: 
                    Option1();                   
                    break;
                case 2:             
                    Option2();
                    break;
                case 3:                 
                    AccountHandle.Option3();
                    break;
                case 4:             
                    AccountHandle.Option4();                    
                    break;
                case 5:

                    Option5();                    
                    break;
                case 6:
                    Option6();
                    break;
                case 7:
                    Program.EnterDetails();
                    break;


            }

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
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

                if (!validEmail())
                {
                    Console.WriteLine("Please put a valid email.");
                    Console.ReadKey();
                    Console.Clear();
                    Option1();

                }

                //check if the info is correct? 
                Console.WriteLine("\nWould you like to submit these details? Enter Y to confirm, \nEnter any other button to try again");

                if (Console.ReadLine() == "y")
                {
                    Option1Confirm();

                }
                else
                {
                    Console.Clear();
                    Option1();

                }


                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Account created. Details will be provided via email");
                Console.WriteLine("Account number is: " + accountNumber);
                Console.WriteLine("Press any button to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            

            
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


            while (File.Exists(accountString + ".txt") && accountNumber < 99999999) {
                accountNumber++;
                accountString = Convert.ToString(accountNumber);

            }

            using (StreamWriter sw = File.CreateText(accountString + ".txt")) {
                sw.WriteLine("First Name|" + firstName);
                sw.WriteLine("Last Name|" + lastName);
                sw.WriteLine("Address|" + address);
                sw.WriteLine("Phone|" + phone);
                sw.WriteLine("Email|" + email);
                sw.WriteLine("AccountNo|" + accountString);
                sw.WriteLine("Balance|0");


            }
            try {

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("dotnettestmail33@gmail.com", "yxcurziyvoziaopv");

                message.From = new MailAddress("dotnettestmail33@gmail.com");
                message.To.Add(new MailAddress("dotnettestmail33@gmail.com"));
                message.Subject = "Online Banking Details";
                message.Body = "Thank you " + firstName + " " +  lastName + "\nYour details are as follows: \nAddress: " + address + "\nPhone number: " + phone;
                Console.WriteLine("Pending, please wait.");
                smtp.Send(message);
            
            }

            catch(Exception e) {
                Console.WriteLine(e);
                Console.ReadLine();
            }


           
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
        //line break for when i scroll
        //search for an account
        static void Option2() {
        
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("           Search for an account          ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("           Enter account number           ");
            Console.WriteLine("\nAccount Number:                         ");
            Console.WriteLine("------------------------------------------");

            Console.SetCursorPosition(16, 5);
            

            string accountNum;
            accountNum = Console.ReadLine();
            Console.WriteLine("\n");

            if (Search(accountNum))
            {

                //i only took the first 7 lines because i didn't want to print the deposit and withdraw stuff.
                present(accountNum);
                Console.WriteLine("Check another account? Enter Y to confirm. \nEnter any other button to go back to the menu.");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    Option2();

                }
                else
                {
                    Console.Clear();
                    MainMenu();
                }


            }
            else {
                Option2();
            
            }
        }


        static void Option5() {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("             Account Statement            ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("           Enter account number           ");
            Console.WriteLine("\nAccount Number:                         ");
            Console.WriteLine("------------------------------------------");


            Console.SetCursorPosition(16, 5);
            
            string accountNum;
            string temp;
            accountNum = Console.ReadLine();
            Console.WriteLine("\n");
            sendThis = "";

            if (Search(accountNum))
            {
    
                string[] lines = File.ReadLines(accountNum + ".txt").Reverse().Take(5).ToArray();

                foreach (string set in lines)
                {

                    string[] splits = set.Split('|');

                    try
                    {
                        if (splits[1].Contains("Deposit") | splits[1].Contains("Withdraw"))
                        {

                            temp = splits[0] + " " + splits[1] + " amount: $" + splits[2] + " total balance: $" + splits[3];
                            sendThis += "\n" + temp;
                            Console.WriteLine(temp);
                        }
                        else if (!File.ReadAllText(accountNum + ".txt").Contains("Deposit") | !File.ReadAllText(accountNum + ".txt").Contains("Withdraw"))
                        {

                            Console.WriteLine("No transactions found in account. Press any button to go back to the menu.");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu();

                        }

                       
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                        
                    
                    }
                    

                }
                      

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Would you like to email the statement? Enter Y to confirm. \nOr any other key to exit to menu.");
                if (Console.ReadLine() == "y")
                {
                    Option5Confirm();

                }
                else
                {
                    Console.Clear();
                    MainMenu();
                }


                Console.WriteLine("Email has been sent. Press any button to go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                MainMenu();


            }
            else { 
            Option5();

            }

        }

        static void Option5Confirm() {

            try
            {

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("dotnettestmail33@gmail.com", "yxcurziyvoziaopv");

                message.From = new MailAddress("dotnettestmail33@gmail.com");
                message.To.Add(new MailAddress("dotnettestmail33@gmail.com"));
                message.Subject = "Bank statement";
                message.Body = "Here is your bank statement: \n" + sendThis;
                Console.WriteLine("Pending, please wait.");
                smtp.Send(message);

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }


        }

        static void Option6() {

            string accountNum;

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("             Delete an account            ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("           Enter account number           ");
            Console.WriteLine("\nAccount Number:                         ");
            Console.WriteLine("------------------------------------------");

            Console.SetCursorPosition(16, 5);

            
            accountNum = Console.ReadLine();
            if (Search(accountNum))
            {
                present(accountNum);

                Console.WriteLine("Are you sure you want to delete this account? \n Enter Y to confirm. Enter any other button to go back to menu.");

                if (Console.ReadLine() == "y")
                {
                    File.Delete(accountNum + ".txt");
                    Console.WriteLine("Account deleted. Press any button to return to the menu");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();


                }
                else
                {
                    Console.Clear();
                    MainMenu();
                }


            }
            else {

                Option6();
            
            }

        }
        //-------------------------------------------------------------------------------------------------------

        public static bool Search(string accountNum) {

       
            Console.WriteLine("\n");

            if (File.Exists(accountNum + ".txt"))
            {

                return true;

            }
            else if (!int.TryParse(accountNum, out accountNumber) | accountNum.Length > 10)
            {
                
                Console.WriteLine("\nPlease put a proper account number");
                Console.ReadKey();
                Console.Clear();
                return false;

            }
            
            else
            {
                
                Console.WriteLine("\nAccount not found.");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            

        }


        static void present(string accountNum) {

            string[] lines = File.ReadLines(accountNum + ".txt").Take(7).ToArray();


            Console.WriteLine("------------------------------------------");
            Console.WriteLine("              Account Details             ");
            Console.WriteLine("------------------------------------------");

            foreach (string set in lines)
            {

                string[] splits = set.Split('|');


                Console.WriteLine("{0}: {1}", splits[0], splits[1]);

            }

            Console.WriteLine("------------------------------------------");

        }


        


    }









}





        



    



