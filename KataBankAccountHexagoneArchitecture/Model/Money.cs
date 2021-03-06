﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Model
{
    public class Money : IEquatable<Money>
    {
        public static Money ValueOf(int value)
        {
            return new Money(value);
        }

        private readonly int _value;

        private Money(int value)
        {
            if (value < 0)
                throw new ArgumentException("money can't not be under zero");
            _value = value;
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public Money Add(Money money)
        {
            return new Money(_value + money._value);
        }

        public Money Substract(Money money)
        {
            return new Money(_value - money._value);
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}
