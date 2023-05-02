using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class InterestCharge: BankAccount
    {
        public InterestCharge(string name, decimal initialbalance) : base(name, initialbalance)
        {
            
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500)
            {
                MakeDeposit( ( Balance * 0.05m ), DateTime.Now, "Interest Charge");
            }

        }
    }
}
