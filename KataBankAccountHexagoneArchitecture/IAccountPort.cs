using BankAccount.Domain.Model;

namespace BankAccount.Domain
{
    public interface IAccountPort
    {
        Money Balance();
        void Deposit(Money money);
        void Withdrawal(Money money);
        string OperationsHistory();
    }
}
