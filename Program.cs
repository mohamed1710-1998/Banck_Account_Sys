﻿using System.Security.Principal;

namespace Exc4_Accounts_
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
        public static  double operator +(Account lhs, Account rhs) { 
            double newBalance  = lhs.Balance + rhs.Balance;
            return newBalance;
        }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        internal static void Display(List<SavingsAccount> savAccounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in savAccounts)
            {
                Console.WriteLine(acc);
            }
        }

        internal static void Deposit(List<SavingsAccount> savAccounts, int v)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in savAccounts)
            {
                if (acc.Deposit(v))
                    Console.WriteLine($"Deposited {v} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {v} to {acc}");
            }
        }

        internal static void Withdraw(List<SavingsAccount> savAccounts, int v)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in savAccounts)
            {
                if (acc.Withdraw(v))
                    Console.WriteLine($"Withdrew {v} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {v} from {acc}");
            }
        }

        internal static void Display(List<CheckingAccount> checAccounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in checAccounts)
            {
                Console.WriteLine(acc);
            }
        }

        internal static void Deposit(List<CheckingAccount> checAccounts, int v)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in checAccounts)
            {
                if (acc.Withdraw(v))
                    Console.WriteLine($"Withdrew {v} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {v} from {acc}");
            }
        }

        internal static void Withdraw(List<CheckingAccount> checAccounts, int v)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in checAccounts)
            {
                if (acc.Withdraw(v))
                    Console.WriteLine($"Withdrew {v} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {v} from {acc}");
            }
        }

        internal static void Display(List<TrustAccount> trustAccounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in trustAccounts)
            {
                Console.WriteLine(acc);
            }
        }

        internal static void Deposit(List<TrustAccount> trustAccounts, int v)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in trustAccounts)
            {
                if (acc.Withdraw(v))
                    Console.WriteLine($"Withdrew {v} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {v} from {acc}");
            }
        }

        internal static void Withdraw(List<TrustAccount> trustAccounts, int v)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in trustAccounts)
            {
                if (acc.Withdraw(v))
                    Console.WriteLine($"Withdrew {v} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {v} from {acc}");
            }
        }
    }

    public class SavingsAccount : Account {

        public double Rate { get; set; }

        public SavingsAccount(string name = "Unnamed Account", double balnace = 0.0, double rate = 0.0) : base(name, balnace)
        {
            Rate = rate;
        }

    }

    public class CheckingAccount : Account
    {
        public CheckingAccount(string Name = "Unnamed Account", double Balance = 0.0,double fee = 1.5):base(Name,Balance) 
        {
            Fee = fee;
        }

        public double Fee { get; set; } = 1.50;

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount - Fee);
        }

    }

    public class TrustAccount : SavingsAccount {

        public int WithdrawalsThisYear = 0;
        public const int MaxWithdrawalsPerYear = 3;

        public TrustAccount(string name = "Unnamed Account", double balnace = 0.0, double rate = 0.0 , int withdrawalsThisYear = 0):base(name , balnace , rate) 
        {
            WithdrawalsThisYear = 0;
        }

        public override bool Deposit(double amount)
        {
            if (amount > 5000)
            {
                return base.Deposit(amount + 50);
            }
            else { 
                return base.Deposit(amount);
            }
        }

        public override bool Withdraw(double amount)
        {

            if (WithdrawalsThisYear >= MaxWithdrawalsPerYear && amount >= Balance*0.20)
            {
                Console.WriteLine("Withdrawal limit reached for the year.");
                return false;
            }
            else {

                WithdrawalsThisYear ++;
                return base.Withdraw(amount);
            }


        }




    }
    public class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
        }
    }
}
