using NPMTK;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
            
            try
            {
                if (args[0] == "1")
                {
                    await TableController.CreateTableAsync(connectionString);
                }
                if (args[0] == "2")
                {
                    await TableController.AddToTableAsync(connectionString, args[1], args[2], args[3]);
                }
                if (args[0] == "3")
                {
                    await TableController.SortUnicValuesTabeAsync(connectionString);
                }
                if (args[0] == "4")
                {
                    await TableController.AddToTable100500ValuesAsync(connectionString);
                }
                if (args[0] == "5")
                {
                    await TableController.SelectorAsync(connectionString);
                }
                if (args[0] == "6")
                {
                    await TableController.TableIndexiser(connectionString);
                }
            } catch
            {
                Console.WriteLine("Простите - сделал все шо мох");
            }
            
       

            


            Console.Read();
        }
    }
}
