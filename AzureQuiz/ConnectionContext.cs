using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureQuiz
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Player> Players { get; set; }
        

        private string connectionString = "https://andreeiths.documents.azure.com:443/";
        private string primaryKey = "EAqLshDZx8UWEgN3QcloccFg7aHYaPIzETHzDF1N48bsAvm2VSw1pHkrV5OFYgZygDDCbeVDyDbgZOwI6Zbgaw==";
        private string databaseName = "QuizGame";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(connectionString, primaryKey, databaseName);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}