using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{


    //    I.Account Customer Name(string)
    //II.Account Type(string ) (allowed types : Current, Deposit, Savings)
    //III.BIC(bank identification code) (integer)
    //IV.Account Number (integer).  This should be unique for all objects of type BankAccount.
    //V.Balance (double)
    //VI.	Account PIN  (integer)

    class BankAccount
    {
        private static int highestAccountNumber = 0;

        public string CustomerName { get; set; }

        private string _accountType;
        public string AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                if (value == "Current" || value == "Deposit" || value == "Savings")
                {
                    _accountType = value;
                }
                else
                {
                    throw new Exception("Cannot set account property: Not a valid account type");
                }
            }
        }

        public int BIC { get; set; }

        private int _accountNumber;
        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        }


        public double Balance { get; set; }

        public int PIN { get; set; }

        // constructor for the account

        public BankAccount(string customerName, string accountType, int bic, double balance, int pin)
        {
            CustomerName = customerName;
            AccountType = accountType;
            BIC = bic;
            Balance = balance;
            PIN = pin;

            _accountNumber = highestAccountNumber + 1;
            highestAccountNumber++;
        }

        public override string ToString()
        {
            return String.Format("AccountType {0}, BIC {1}, Balance {2}, PIN {3} AccountNumber {4} ", AccountType,
                BIC, Balance, PIN, AccountNumber);
        }

        /* Takes a decimal adds it to the balance in the account
         * and returns the new balance 
         */

        public double Lodge(double amount)
        {
            Balance += amount;
            return Balance;
        }

        /* 
         * Takes a decimal and a PIN, if the PIN is correc it deducts it to the balance in the account
         * and returns true otherwise it returns FALSe 
         */

        public bool Withdraw(double amount, int pin)
        {

            if (pin == PIN)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*This is a hard one because we need to return a balance
         * but also want to know if the PIN was correct. It uses an out parameter
         * which will be true when the PIN is valid.
         * If the pin is not valid it returns 0 as the balance and the second parameter is set to false.
         */

        public double GetBalance(int pin, out bool isValidPIN)
        {
            if (PIN == pin)
            {
                isValidPIN = true;
                return Balance;
            }
            else
            {
                isValidPIN = false;
                return 0;
            }
        }




        /* This takes two PIN numbers as arguments, if the first number
         * equals the stored PIN it changes the stored PIN to the second number and returns true
         * otherwise it returns false and the stored PIN doesn't change.
         */

        public bool ChangePin(int newPin, int oldPin)
        {
            if (oldPin == PIN)
            {
                PIN = newPin; 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
