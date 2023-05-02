using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApplication;

public class LineOfCreditAccount: BankAccount
{
    public LineOfCreditAccount(string name,  decimal initalbalanace, decimal lineofcredit) : base(name, initalbalanace, lineofcredit)
    {
        
    }
    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            MakeWithDrawl( Balance * -.07m, DateTime.Now, "Overdue Bal Charge");
        }
    }

    public override Transaction? isOverDraft(decimal balance)
    {
        if (balance < 0)
            return new Transaction(-20, "over draft fees", DateTime.Now );
        
        return default;
    }
}
