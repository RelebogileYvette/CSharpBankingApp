using System;
using CSharpBankingApp;
using System.Collections.Generic;

namespace CSharpBankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to CSharp Banking App ===");

            // Create a new account
            var account = new Account("Basetsana Sebokolodi", "1234", AccountType.Savings);
            Console.WriteLine("Account created:");
            Console.WriteLine(account.GetAccountSummary());

            // A  deposit
            account.Deposit(1000m, "1234");
            Console.WriteLine("\nAfter deposit:");
            Console.WriteLine(account.GetAccountSummary());

            // A withdrawal
            account.Withdraw(200m, "1234");
            Console.WriteLine("\nAfter withdrawal:");
            Console.WriteLine(account.GetAccountSummary());

            // Show transaction history
            Console.WriteLine("\nTransaction history:");
            foreach (var t in account.GetTransactionHistory())
            {
                Console.WriteLine(t);
            }
        }
    }
}
