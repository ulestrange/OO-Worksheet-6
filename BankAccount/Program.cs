using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {



            BankAccount myAccount = GetAccountDetailsFromUser();

            Console.WriteLine(myAccount.ToString());

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
    }
}












