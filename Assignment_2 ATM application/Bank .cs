using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    public  class Bank
    {
        
        private List<Account> Accounts;

        public Bank()
        {
            Accounts = new List<Account>();
            //Creating 10 default accounts
            for (int i = 0; i < 10; i++)
            {
                Accounts.Add(new Account(100 + i,  $"Default Account {100 + i}", 100 , 0.03));
            }
        }
        public Account RetrieveAccount(int accountNumber)
        {
            return Accounts.Find(account => account.AccountNumber == accountNumber);

        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        public void DisplayAccounts()
        {
            Console.WriteLine("Default Accounts:");
            foreach (var account in Accounts)
            {
                account.DisplayAccountInfo();
                Console.WriteLine();
            }
        }

    }
}
