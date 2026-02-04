using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CashGwejh.Models
{
    public class HomeStatsModel : INotifyPropertyChanged
    {
        public decimal? BankAmount { get; set { field = value; OnPropertyChanged(); } }
        public decimal? CashAmount { get; set { field = value; OnPropertyChanged(); } }
        public decimal? ExternalBankAmount { get; set { field = value; OnPropertyChanged(); } }
        public decimal? EWalletAmount { get; set { field = value; OnPropertyChanged(); } }
        public decimal? DebtAmount { get; set { field = value; OnPropertyChanged(); } }
        public decimal? TotalAmount { get; set { field = value; OnPropertyChanged(); } }

        public string F_BankAmount { get { return Utils.CurrencyHelper.FormatCurrency(BankAmount ?? 0, "IDR"); } }
        public string F_CashAmount { get { return Utils.CurrencyHelper.FormatCurrency(CashAmount ?? 0, "IDR"); } }
        public string F_ExternalBankAmount { get { return Utils.CurrencyHelper.FormatCurrency(ExternalBankAmount ?? 0, "IDR"); } }
        public string F_EWalletAmount { get { return Utils.CurrencyHelper.FormatCurrency(EWalletAmount ?? 0, "IDR"); } }
        public string F_DebtAmount { get { return Utils.CurrencyHelper.FormatCurrency(DebtAmount ?? 0, "IDR"); } }
        public string F_TotalAmount { get { return Utils.CurrencyHelper.FormatCurrency(TotalAmount ?? 0, "IDR"); } }

        public void SyncWithTransaction()
        {
            decimal? bank = 0;
            decimal? cash = 0;
            decimal? external = 0;
            decimal? ewallet = 0;
            decimal? debt = 0;

            foreach (var trx in StaticBinding.TransactionsList)
            {
                var sign = trx.SelectedTransactionType == TransactionType.Expense ? -1 : 1;
                var value = trx.Amount * sign;

                switch (trx.SelectedAccountType)
                {
                    case AccountType.Bank:
                        bank += value;
                        break;

                    case AccountType.Cash:
                        cash += value;
                        break;

                    case AccountType.CreditCard:
                        debt += Math.Abs(value ?? 0);
                        break;

                    case AccountType.DigitalWallet:
                        ewallet += value;
                        break;
                }
            }

            BankAmount = bank;
            CashAmount = cash;
            ExternalBankAmount = external;
            EWalletAmount = ewallet;
            DebtAmount = debt;
            TotalAmount = bank + cash + ewallet - debt;

            OnPropertyChanged(string.Empty);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
    public class HomeMilestoneModel
    {
        public string Name { get; set; }
        public decimal? Target { get; set; }
        public int? Percent { get; set; }
    }
}
