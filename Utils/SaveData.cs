using CashGwejh.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;

namespace CashGwejh.Utils
{
    public static class SaveData
    {
        public static async Task SaveTransaction()
        {
            var path = Path.Combine(
                FileSystem.AppDataDirectory,
                "transactions.json"
            );

            var json = JsonSerializer.Serialize(StaticBinding.TransactionsList);
            await File.WriteAllTextAsync(path, json);
        }

        public static void LoadTransaction()
        {
            var path = Path.Combine(
                FileSystem.AppDataDirectory,
                "transactions.json"
            );

            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            var loaded = JsonSerializer.Deserialize<List<ManageTransactionViewModel>>(json);

            if (loaded == null) return;

            StaticBinding.TransactionsList.Clear();
            foreach (var trx in loaded.OrderByDescending(x=>x.CreatedAt))
                StaticBinding.TransactionsList.Add(trx);
        }
        public static void SaveSettings()
        {
            
        }
    }
}
