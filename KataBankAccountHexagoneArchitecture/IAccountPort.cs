using System;
using System.Collections.Generic;
using System.Text;
using BankAccount.Domain.Model;

namespace BankAccount.Domain
{
    public interface IAccountPort
    {
        Money Balance();
        void Deposit(Money money);
    }
}
