using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    public class Account
    {
        public int AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public double Balance { get; private set; }
        public double InterestRate { get; private set; }
        private List<string> Transactions;
        public Account(int accountNumber, string accountHolder, double intialBalance, double interestRate)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = intialBalance;
            InterestRate = interestRate;
            Transactions = new List<string>
            {
                $"Account created with intial balance- {intialBalance:c}"

            };
        
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited: {amount: c}");
        }
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");

            }
            else
            {
                Balance -= amount;
                Transactions.Add($"Withdraw: {amount:c}");
            }
        }
        public void DisplayTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
        public void DisplayAccountInfo()
        {
            
            Console.WriteLine(" ========= Welcome create Account =======");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Balance: {Balance:c}");
            Console.WriteLine($"Interest Rate: {InterestRate:p}");



        }

       
        
           
        
    }
}
