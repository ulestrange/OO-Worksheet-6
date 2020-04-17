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


        public double Balance { get;  set; }

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

        /* Takes a decimal deducts it to the balance in the account
         * and returns the new balance 
         */

        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }

        public double GetBalance()
        {
            return Balance;
        }

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
