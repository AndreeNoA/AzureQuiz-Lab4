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
        

        private string connectionString = "https://localhost:8081";
        private string primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private string databaseName = "Quiz";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(connectionString, primaryKey, databaseName);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}