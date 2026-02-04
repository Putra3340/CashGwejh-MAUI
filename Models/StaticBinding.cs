using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CashGwejh.Models
{
    public static class StaticBinding
    {
        public static HomeStatsModel HomeStats = new();

        public static ObservableCollection<ManageTransactionViewModel> TransactionsList = new();
    }
}
