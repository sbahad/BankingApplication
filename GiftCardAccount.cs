using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    internal class GiftCardAccount: BankAccount
    {
        private readonly decimal _montendrefillamt;

        public GiftCardAccount(string name, decimal initialbalance, decimal montendrefillamt): base(name,initialbalance)
        {
            _montendrefillamt = montendrefillamt;
        }

        public override void PerformMonthEndTransactions()
        {
            if (_montendrefillamt  != 0)
            {
                MakeDeposit(_montendrefillamt, DateTime.Now, "Refill Amount");
            }
        }
    }
}
