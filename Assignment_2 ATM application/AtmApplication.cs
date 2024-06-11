using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    public class AtmApplication
    {
        private Bank bank;
        public AtmApplication()
        {
            bank = new Bank();
        }
        public void Run()
        {
            while (true)
            {
                DisplayMainMenu();
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {

                        case 1:
                            CreateAccount();
                            break;

                        case 2:
                            SelectAccount();
                            break;
                        case 3:
                            DispalyDefaultAccounts();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice.Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.please enter a number.");
                }
            }
        }
        private void DisplayMainMenu()
        {
            Console.WriteLine(" ========Welcome to the ATM Application===== ");
            Console.WriteLine("Choose the following options by the number associated with the below options");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Default accounts");
            Console.WriteLine("4. Exit");

        }
        private void CreateAccount()
        {
            Console.WriteLine("Enter Account Holder Name");
            string accountHolder = Console.ReadLine();
            Console.WriteLine("Enter Account Number (Account Number must be between 100 and 1000)");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Intial Balance");
            double intialBalance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Annual Intrest Rate ");
            double interestRate = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountNumber, accountHolder, intialBalance, interestRate);
            bank.AddAccount(newAccount);
            Console.WriteLine("Done Successfully!");
            Console.WriteLine("Welcome,{accountHolder}!");


        }
        private void SelectAccount()
        {
            Console.WriteLine("Enter Account Number");
            int accountNumber = int.Parse(Console.ReadLine());
            Account account = bank.RetrieveAccount(accountNumber);

            if (account != null)
            {
                bool exitAccountMenu = false;
                while (!exitAccountMenu)
                {

                 DispalyAccountMenu();
                 int choice;

                 if (int.TryParse(Console.ReadLine(), out choice))
                    {

                        switch (choice)

                        {
                            case 1:
                                Console.WriteLine($"Balance: {account.Balance:c}");
                                break;
                            case 2:
                                Console.Write("Enter amount to deposit:");
                                double depositAmount = double.Parse(Console.ReadLine());
                                account.Deposit(depositAmount);

                                break;
                            case 3:
                                Console.Write("Enter amount to withdraw:");
                                double withdrawAmount = double.Parse(Console.ReadLine());
                                account.Withdraw(withdrawAmount);
                                break;
                            case 4:
                                account.DisplayTransactions();
                                break;
                            case 5:
                                Console.WriteLine("Do you want to exit? [y/n]: ");
                                string exitChoice = Console.ReadLine();
                                if (exitChoice == "y")
                                {
                                    exitAccountMenu = true;
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        private void DispalyDefaultAccounts()
        {
            bank.DisplayAccounts();
        }
        private void DispalyAccountMenu()
        {
            Console.WriteLine("Choose the following options");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Dispaly Transactions");
            Console.WriteLine("5. Exit Account");

        }
    }
}









