using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace AzureQuiz
{
    public class Login
    {
        private ConnectionContext connection;
        public Login(ConnectionContext connection)
        {
            this.connection = connection;
        }
        public Player PickPlayer()
        {
            Console.WriteLine("Welcome to this quiz. Please enter your name");

            string alias = Console.ReadLine();
            //Query to look if player exist
            var query = from player in connection.Players
                        where player.Name == alias
                        select player;

            if (query.Count() >= 1)
            {
                Console.WriteLine("Welcome back");
                Thread.Sleep(2000);
                return query.First();
            }
            else
            {
                Player player = new Player()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = alias,
                    Score = 0
                };
                connection.Players.Add(player);
                connection.SaveChanges();
                return player;
            }
        }

    }
}
