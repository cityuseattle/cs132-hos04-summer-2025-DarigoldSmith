// code library's access
using System;
using System.Formats.Asn1;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

public class BankAccount //project name
{
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }
    //deposit money function
    public void Deposit(decimal amount)
    {
        if (amount > 0) //verify positive deposit
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");
        }
        else
        {
            //error message if negative
            Console.WriteLine("Deposit amount must be positive");
        }
    }

    //withdraw money function and checking balance
    public bool Withdraw(decimal amount)
    {
        //verify positive account, display message options
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
            return false;
        }
        else if (amount <= 0)
        {
            Console.WriteLine("Withdrawl amount must be positive.");
            return false;
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Withdrew: {amount}. New Balance: {balance}");
            return true;
        }
    }
    public decimal GetBalance()
    {
        return balance;
    }  
    
}
//primary function to test all methods
class Program
{

    static void Main(string[] args) //main function
    {

        BankAccount myAccount = new BankAccount(1000); //initial amount balance

        myAccount.Deposit(500); //deposit amount
        if (myAccount.Withdraw(200)) //withdraw amount
        {
            //update Main function to communicate success and balance
            Console.WriteLine($"Withdrawal successful. Current Balance: {myAccount.GetBalance()}");
        }
        else
        {
            //update Main function to communicate failed attempt
            Console.WriteLine("Withdrawal failed.");
        }
    }
}