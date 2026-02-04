using KotlinX.Serialization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static Java.Util.Jar.Attributes;
using static System.Net.Mime.MediaTypeNames;

namespace CashGwejh.Models
{
    public class ManageTransactionViewModel : INotifyPropertyChanged
    {
        public Array Currencies => Enum.GetValues(typeof(Currency));
        public Array TransactionTypes => Enum.GetValues(typeof(TransactionType));
        public Array Categories => Enum.GetValues(typeof(Category));
        public Array AccountTypes => Enum.GetValues(typeof(AccountType));

        public Currency SelectedCurrency { get; set { field = value; OnPropertyChanged(); } }
        public TransactionType SelectedTransactionType { get; set { field = value; OnPropertyChanged(); } }
        public Category SelectedCategory { get; set { field = value; OnPropertyChanged(); } }
        public AccountType SelectedAccountType { get; set { field = value; OnPropertyChanged(); } }

        public decimal? Amount { get; set { field = value; OnPropertyChanged(); } }
        public string? Notes { get; set { field = value; OnPropertyChanged(); } }
        public DateTime CreatedAt { get; set { field = value; OnPropertyChanged(); } } = DateTime.Now;

        public string F_Account { get { return SelectedAccountType.ToString(); } }
        public string F_Amount { get { return Utils.CurrencyHelper.FormatCurrency(Amount ?? 0, "IDR"); } }
        public string F_Notes { get { return Notes; } }
        public string F_CreatedAt { get { return CreatedAt.ToString("dd MMM yyyy HH:mm"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

}
