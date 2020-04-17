using System;

namespace BankAccount
{
    class Program
    {


        static void Main(string[] args)
        {
            string choice;
            bool writeMenu = true;


            //  BankAccount myAccount = GetAccountDetailsFromUser(); 

            BankAccount myAccount = CreateTestAccount(); // to save typing while testing.

            while (writeMenu)
            {
                choice = GetUserChoiceFromMenu();

                switch (choice)
                {
                    case "1":
                        LodgeMoney(myAccount);
                        break;
                    case "2":
                        WithDrawMoney(myAccount);
                        break;
                    case "3":
                        CheckBalance(myAccount);
                        break;
                    case "4":
                        ChangePIN(myAccount);
                        break;
                    case "5":
                        writeMenu = false;
                        Console.WriteLine("Thank you for banking with us today");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            Console.WriteLine(myAccount.ToString());

        }

        /* This asks the user for the current PIN and a new PIN
         * if the current PIN matches the stored PIN then the new PIN is stored.
         * both PINs need to be integers
         */

        static void ChangePIN(BankAccount account)
        {
            //note this method uses a different approach to testing 
            // when the PINs are integers.

            bool isValidPIN1, isValidPIN2;
            int newPIN, oldPIN;

            Console.WriteLine("Enter existing PIN");
            string pinEntered = Console.ReadLine();
            isValidPIN1 = int.TryParse(pinEntered, out oldPIN);
            Console.WriteLine("Enter new PIN");
           pinEntered = Console.ReadLine();
            isValidPIN2 = int.TryParse(pinEntered, out newPIN);

            if (!isValidPIN1 || !isValidPIN2)
            {
                Console.WriteLine("Invalid PIN entered, both PINS must be integers");
            }
            else
            {

                bool success = account.ChangePin(newPIN, oldPIN);

                if (success)
                {
                    Console.WriteLine("Pin changed");
                }
                else
                {
                    Console.WriteLine("PIN not changed");
                }
            }
        }




        /* This takes an account and asks the uses for a sum of money.
         * if the amount entered is valid it lodges the money to the account
         * otherwise it tells the user the amount is invalid
         */
        static private void LodgeMoney(BankAccount account)
        {
            Console.WriteLine("Please enter the amount :");
            try
            {
                double amount = Double.Parse(Console.ReadLine());
                double newBalance = account.Lodge(amount);
                Console.WriteLine("Your new balance is {0}", newBalance);


            }
            catch
            {
                Console.WriteLine("Invalid amount entered");
            }
        }

        /* This methoid takes a bank account
         * it asks for a PIN and an amount
         * and if both are valid withdraws that amount from the account
         * and writes out the new balance.
         * If the PIN or the amount don't parse it says invalid data entered.
         * if the PIN is not correc it says withdrawal failed
         */

        static private void WithDrawMoney(BankAccount account)
        {
            Console.WriteLine("Please enter your pin");

            try
            {
                int pin = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the amount :");

                double amount = Double.Parse(Console.ReadLine());
                bool success = account.Withdraw(amount, pin);

                if (success)
                {
                    bool isBalanceCorrect;
                    double newBalance = account.GetBalance(pin, out isBalanceCorrect);
                    if (isBalanceCorrect)
                    {
                        Console.WriteLine("Your new balance is {0}", newBalance);
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal failed");
                }
            }

            catch
            {
                Console.WriteLine("Invalid amount or PIN entered");
            }
        }

        /* this method takes a bank account
         * it asks for a PIN and if the PIN is correct it outputs
         * the balance.
         * If an invalid, non integer PIN is entered it says INValid PIN entered.
         * if an incorrect PIN is entered is says balance unavailable
         */

        static private void CheckBalance(BankAccount account)
        {
            try
            {
                Console.WriteLine("Please enter a PIN");
                int pin = int.Parse(Console.ReadLine());
                bool isPINCorrect;
                double newBalance = account.GetBalance(pin, out isPINCorrect);
                if (isPINCorrect)
                {
                    Console.WriteLine("Your balance is {0}", newBalance);
                }
                else
                {
                    Console.WriteLine("Balance unavailable at the moment");
                }
            }
            catch
            {
                Console.WriteLine("Invalid PIN entered");
            }


        }


        /* this method asks the user to input
         * details for a new bank account and returns a new BankAccount object
         */

        static public BankAccount GetAccountDetailsFromUser()
        {
            string name;
            string accountType;
            int bic;
            double balance;
            int pin;



            Console.Write("Customer Name :");
            name = Console.ReadLine();

            Console.Write("Account Type :");
            accountType = Console.ReadLine();

            Console.Write("BIC :");
            bic = int.Parse(Console.ReadLine());

            Console.Write("Balance :");
            balance = double.Parse(Console.ReadLine());

            Console.Write("PIN :");
            pin = int.Parse(Console.ReadLine());

            BankAccount newAccount = new BankAccount(name, accountType, bic, balance, pin);

            return newAccount;


        }

        /* This is a private method for testing purposes
         * it returns a bank acoount with some hardcoded details
         */

        static private BankAccount CreateTestAccount()
        {
            return new BankAccount("Una", "Current", 654321, 1000000, 1234);
        }

        /* this prints out a menu of choices and returns whatever the user entered as a string
         * if the user enters an invalid choice they are given the menu again.
         * it keeps looping until the user enters a valid choice
         */

        public static string GetUserChoiceFromMenu()
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1: Lodge, 2: Withdraw, 3: Check Balance, 4: Change PIN, 5: Exit");

                string choice = Console.ReadLine();

                if ((choice == "1") || (choice == "2") || (choice == "3") || (choice == "4") || (choice == "5"))
                {
                    return choice;
                }

            }

        }
    }
}












