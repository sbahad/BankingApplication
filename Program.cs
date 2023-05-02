// See https://aka.ms/new-console-template for more information
using BankingApplication;

var bankAccount2 = new BankAccount("sanjay1", 2000);
bankAccount2.MakeWithDrawl(1000, DateTime.Now, "withdrawl for buying furnitre");
bankAccount2.MakeDeposit(500, DateTime.Now, "withdrawl for buying furnitre");

Console.WriteLine(bankAccount2.Owner);
Console.WriteLine(bankAccount2.Balance);
Console.WriteLine(bankAccount2.Number);
Console.WriteLine(bankAccount2.GetAccountHistory());



List<BankAccount> listbankAc = new List<BankAccount>();
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithDrawl(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithDrawl(50, DateTime.Now, "buy groceries");
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
//giftCard.PerformMonthEndTransactions();
listbankAc.Add(giftCard);
//Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestCharge("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithDrawl(250, DateTime.Now, "Needed to pay monthly bills");
//savings.PerformMonthEndTransactions();
listbankAc.Add(savings);
//Console.WriteLine(savings.GetAccountHistory());


var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 500);
// How much is too much to borrow?
lineOfCredit.MakeWithDrawl(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Deposit small amount");
lineOfCredit.MakeWithDrawl(5000m, DateTime.Now, "Withdraw Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Deposit Partial restoration on repairs");
//lineOfCredit.PerformMonthEndTransactions();
listbankAc.Add(lineOfCredit);
//Console.WriteLine(lineOfCredit.GetAccountHistory());

foreach (var credit in listbankAc)
{
    credit.PerformMonthEndTransactions();
    Console.WriteLine(credit.GetAccountHistory());
}

