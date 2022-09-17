using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Linq;


namespace DotNetBankApp
{
    class AccountHandle
    {
        public static int accountNumber;

        public static string accountNum;
        public static double validDep = 0;
        public static string deposit;
        public static string withdraw;
        public static double validWith = 0;
        public static string takeout;
        public static double putIn;
        public static double putThisIn;
        public static string putThisBackInFile;


        //this has the ability to change one line
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------
        //Deposit

        public static void Option3()
        {

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("                 Deposit                  ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("            Enter the details             ");
            Console.WriteLine("\nAccount Number: ");
            Console.WriteLine("Amount: ");
            Console.WriteLine("------------------------------------------");

            
            

            Console.SetCursorPosition(16, 5);

            

            try
            {
                accountNum = Console.ReadLine();
                Console.WriteLine("\n\n");


                if (File.Exists(accountNum + ".txt"))
                {
                    Console.SetCursorPosition(1, 8);
                    Console.WriteLine("Account found, please enter deposit amount");
                    Console.SetCursorPosition(8, 6);
                    deposit = Console.ReadLine();
                    Console.SetCursorPosition(1, 8);

                    if (double.TryParse(deposit, out validDep) && validDep > 0)
                    {

                        
                        string[] lines = File.ReadAllLines(accountNum + ".txt");

                        foreach (string set in lines) {
                            string[] splits = set.Split('|');

                            if (splits[0].Contains("Balance"))
                            {
                                takeout = splits[1];
                                // Console.WriteLine("\n" + takeout + "\n");
                                // Console.WriteLine(validDep);

                                try
                                {
                                    putIn = Convert.ToDouble(takeout);

                                    putThisIn = putIn + validDep;


                                    putThisBackInFile = Convert.ToString(putThisIn);
                                }
                                catch (InvalidCastException e)
                                {
                                    throw e;

                                }


                                lineChanger("Balance|" + putThisBackInFile, accountNum + ".txt", 7);


                                using (FileStream fs = new FileStream(accountNum + ".txt", FileMode.Append, FileAccess.Write))
                                using (StreamWriter sw = new StreamWriter(fs))
                                {
                                    sw.WriteLine(DateTime.Today.ToString("dd.MM.yyyy") + "|Deposit|" + deposit + "|" + putThisBackInFile);

                                }



                                Console.WriteLine("\n Successfully added $" + deposit + " to the account.");

                                Console.WriteLine("Would you like to deposit more? Enter Y to confirm.\n Press any other button to go back to the menu.");

                                if (Console.ReadLine() == "y")
                                {
                                    Console.Clear();
                                    Option3();

                                }
                                else
                                {
                                    Console.Clear();
                                    AccountClass.MainMenu();
                                }

                                

                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadKey();
                        Console.Clear();
                        Option3();


                    }

                }
                else if (!int.TryParse(accountNum, out accountNumber) | accountNum.Length > 10)
                {
                    Console.WriteLine("Please put in a valid account number");
                    Console.ReadKey();
                    Console.Clear();
                    Option3();

                }
                else
                {

                    Console.WriteLine("Please put in a valid account number");
                    Console.ReadKey();
                    Console.Clear();
                    Option3();
                }

            }

            
            catch (InvalidCastException e)
            {

                if (e.Data == null)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please press any key to exit application. Contact administrator for support.");
                    Console.ReadKey();

                }


            }

    
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //Withdraw

        public static void Option4() {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("                 Withdraw                 ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("            Enter the details             ");
            Console.WriteLine("\nAccount Number: ");
            Console.WriteLine("Amount: ");
            Console.WriteLine("------------------------------------------");

            Console.SetCursorPosition(16, 5);
            
            try
            {
                accountNum = Console.ReadLine();
                Console.WriteLine("\n\n");


                if (File.Exists(accountNum + ".txt"))
                {
                    Console.SetCursorPosition(1, 8);
                    Console.WriteLine("Account found, please enter withdraw amount");
                    Console.SetCursorPosition(8, 6);
                    withdraw = Console.ReadLine();
                    Console.SetCursorPosition(1, 8);

                    if (double.TryParse(withdraw, out validWith) && validWith > 0)
                    {


                        string[] lines = File.ReadAllLines(accountNum + ".txt");

                        foreach (string set in lines)
                        {
                            string[] splits = set.Split('|');

                            if (splits[0].Contains("Balance"))
                            {
                                takeout = splits[1];
                                // Console.WriteLine("\n" + takeout + "\n");
                                // Console.WriteLine(validDep);

                                try
                                {
                                    putIn = Convert.ToDouble(takeout);

                                    if (putIn < validWith) {

                                        Console.WriteLine("Amount must not be larger than the Balance.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Option4();


                                    }

                                    putThisIn = putIn - validWith;


                                    putThisBackInFile = Convert.ToString(putThisIn);
                                }
                                catch (InvalidCastException e)
                                {
                                    throw e;

                                }


                                lineChanger("Balance|" + putThisBackInFile, accountNum + ".txt", 7);


                                using (FileStream fs = new FileStream(accountNum + ".txt", FileMode.Append, FileAccess.Write))
                                using (StreamWriter sw = new StreamWriter(fs))
                                {
                                    sw.WriteLine(DateTime.Today.ToString("dd.MM.yyyy") + "|Withdraw|" + withdraw + "|" + putThisBackInFile);

                                }



                                Console.WriteLine("\n Successfully taken $" + withdraw + " from the account.");
                                Console.WriteLine("Would you like to withdraw more? Enter Y to confirm.\n Press any other button to go back to the menu.");

                                if (Console.ReadLine() == "y")
                                {
                                    Console.Clear();
                                    Option4();

                                }
                                else
                                {
                                    Console.Clear();
                                    AccountClass.MainMenu();
                                }

                              
                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadKey();
                        Console.Clear();
                        Option4();


                    }

                }
                else if (!int.TryParse(accountNum, out accountNumber) | accountNum.Length > 10)
                {
                    Console.WriteLine("Please put in a valid account number");
                    Console.ReadKey();
                    Console.Clear();
                    Option4();

                }
                else
                {

                    Console.WriteLine("Please put in a valid account number");
                    Console.ReadKey();
                    Console.Clear();
                    Option4();
                }

            }

            //fix this
            catch (InvalidCastException e)
            {

                if (e.Data == null)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please press any key to exit application. Contact administrator for support.");
                    Console.ReadKey();

                }


            }












        }








    }
}
