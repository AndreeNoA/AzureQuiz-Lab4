using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace AzureQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new ConnectionContext();                                                
            connection.Database.EnsureCreated();

            Menu menu = new Menu();
            menu.StartMenu(connection);

        }
    }
}
