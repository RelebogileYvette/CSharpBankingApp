using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace CSharpBankingApp
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Interest,
        TransferIn,
        TransferOut
    }

    public class Transaction
    {
        [JsonPropertyName("type")]
        public TransactionType Type { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonConstructor]
        public Transaction(TransactionType type, decimal amount, DateTime timestamp, string description)
        {
            Type = type;
            Amount = amount;
            Timestamp = timestamp;
            Description = description ?? string.Empty;
        }

        public override string ToString()
        {
            var culture = CultureInfo.CreateSpecificCulture("en-ZA");
            return $"{Timestamp:yyyy-MM-dd HH:mm} | {Type} | {Amount.ToString("C2", culture)} | {Description}";
        }
    }
}
