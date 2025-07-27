using Xunit;
using CSharpBankingApp;
using System;


public class TransactionTests
    {
        [Fact]
        public void ToString_IncludesTypeAmountAndDescription()
        {
            var t = new Transaction(
                TransactionType.Deposit,
                250m,
                new DateTime(2025, 01, 01, 10, 30, 00),
                "Initial deposit");

            var s = t.ToString();

            Assert.Contains("Deposit", s);
            Assert.Contains("Initial deposit", s);
            Assert.Contains("R", s); // SA Rand formatting
        }
    }
