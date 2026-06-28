public class TrustAccount : SavingsAccount
{
    private int withdrawalCount = 0;
    private const int MaxWithdrawals = 3;
    private const double BonusThreshold = 5000.0;
    private const double BonusAmount = 50.0;

    public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0)
        : base(name, balance, interestRate)
    {
    }

    public override bool Deposit(double amount)
    {
        // Call base deposit
        bool result = base.Deposit(amount);
        if (result && amount >= BonusThreshold)
        {
            Balance += BonusAmount; // add bonus
        }
        return result;
    }

    public override bool Withdraw(double amount)
    {
        // Check withdrawal count and limit
        if (withdrawalCount >= MaxWithdrawals)
            return false;
        // Check amount less than 20% of balance
        if (amount >= Balance * 0.2)
            return false;
        // Perform withdrawal using base
        bool result = base.Withdraw(amount);
        if (result)
        {
            withdrawalCount++;
        }
        return result;
    }

    public override string ToString()
    {
        return $"[Trust Account: {Name}: {Balance:C}, Interest Rate: {InterestRate}%, Withdrawals left: {MaxWithdrawals - withdrawalCount}]";
    }
}
