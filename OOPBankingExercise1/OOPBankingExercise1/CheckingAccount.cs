public class CheckingAccount : Account
{
    private const double Fee = 1.50;

    public CheckingAccount(string name = "Unnamed Account", double balance = 0.0)
        : base(name, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        double total = amount + Fee;
        if (Balance - total >= 0)
        {
            Balance -= total;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"[Checking Account: {Name}: {Balance:C}, Fee: {Fee:C}]";
    }
}
