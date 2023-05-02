using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication;

public class Transaction
{
    public decimal Amount { get;  }
    public string Notes { get;  }
    public DateTime Date { get; }

    public Transaction(decimal amount , string notes, DateTime date)
    {
        Amount = amount;
        Notes = notes;
        Date = date;
    }
}
