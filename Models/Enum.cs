using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CashGwejh.Models
{
    public enum Currency
    {
        USD,
        EUR,
        GBP,
        JPY,
        IDR,
    }
    public enum TransactionType
    {
        Income,
        Expense,
        Transfer
    }
    public enum Category
    {
        Food,
        Utilities,
        Entertainment,
        Transportation,
        Healthcare,
        Salary,
        Investment,
        Others
    }
    public enum AccountType
    {
        Cash,
        Bank,
        CreditCard,
        DigitalWallet
    }
    public static class EnumUtils
    {
        public static string ToFriendly(this Enum value) => Regex.Replace(value.ToString(), "(\\B[A-Z])", " $1");
    }
}
