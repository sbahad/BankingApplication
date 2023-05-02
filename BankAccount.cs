using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingApplication;

public class BankAccount
{
    private static int ACNUM = 1010102022; 

    List<Transaction> transactions = new List<Transaction>();


    private readonly decimal _lineofcredit = 0;

    public string Owner { get; set; }

    public string Number { get; }

    public decimal Balance {
        get { 
            decimal _balance = 0;
            foreach (var transaction in transactions)
            {
                _balance = _balance + transaction.Amount;
            }
            return _balance;
        }
    }



    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
            throw new InvalidProgramException("amt > 0");
        transactions.Add(new Transaction(amount, note, date));
    }

    public void MakeWithDrawl(decimal amount, DateTime date, string note)
    { 
       //if  ( amount < 0 )
       //     throw new InvalidProgramException("amt > 0");
        Transaction overdraft = isOverDraft( Balance - amount + _lineofcredit );


        transactions.Add(new Transaction( Math.Abs (amount) * -1m , note, date));

        //add overdraft fees
        if (overdraft != null)
            transactions.Add(overdraft);
    }

    public string GetAccountHistory()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Account name:{Owner}");
        foreach (var transaction in transactions)
        {
            sb.AppendLine($"{transaction.Notes},{transaction.Date},{transaction.Amount}");

        }
        sb.AppendLine($"Current Balance: {Balance}");
        return sb.ToString();
    }
    public BankAccount(string name, decimal initialbalance, decimal lineofcredit) : this(name, initialbalance)
    {
        _lineofcredit = lineofcredit;
    }
    public BankAccount(string name, decimal initialbalance)
    {
        ACNUM = ACNUM + 1;
        Owner = name;
        Number = ACNUM.ToString();
        if (initialbalance > 0)
            transactions.Add(new Transaction(initialbalance, "Initial Balance", DateTime.Now));
    }

    public virtual void PerformMonthEndTransactions()
    {
        throw new InvalidProgramException("not implemented");
    }
    public virtual Transaction? isOverDraft( decimal balance)
    {
        if (balance < 0)
            throw new InvalidProgramException("-ve balance not allowed");
        else
            return default;
    }
}
