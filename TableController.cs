using System.Data.SqlClient;
using NPMTK;

namespace NPMTK
{
    internal class TableController
    {


        public static async Task CreateTableAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, FIO NVARCHAR(100) NOT NULL, Date DATE NOT NULL, Sex VARCHAR(3) NOT NULL)";
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Таблица Users заполнена");
            }
        }

        public static async Task AddToTableAsync(string connectionString, string FIO, string Date, string Sex)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                string sqlExpression = $"INSERT INTO Users (FIO, Date, Sex) VALUES ({FIO}, {Date}, {Sex})";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
            Console.Read();
        }

        public static async Task SortUnicValuesTabeAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT DISTINCT FIO, Date FROM Users;";
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) // если есть данные
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);

                    Console.WriteLine($"{columnName1}\t{columnName2}");

                    while (await reader.ReadAsync()) // построчно считываем данные
                    {
                        object FIO = reader.GetValue(0);
                        object Date = reader.GetValue(1);
                        Console.WriteLine($" \t{FIO} \t{Date}");
                    }
                }

                await reader.CloseAsync();
            }
            Console.Read();
        }

        public static async Task AddToTable100500ValuesAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "INSERT INTO Users (FIO, Date, Sex) VALUES " +
                    "(Fanar Abab Baba, 2022-10-10, man)," +
                    "(Jafna Huafna Dudu, 2022-10-10, not), " +
                    "(Call Me Peep, 2022-10-10, man)" +
                    "(Call Me Gay, 2022-10-10, man)" +
                    "(Call Me Qeep, 2022-10-10, man)" +
                    "(Call Me Seep, 2022-10-10, man)" +
                    "(Call Me Reep, 2022-10-10, man)" +
                    "(Call Me Deep, 2022-10-10, man)" +
                    "(Call Me Ceep, 2022-10-10, man)" +
                    "(Call Me Teep, 2022-10-10, man)";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                sqlExpression = $"INSERT INTO Users (SELECT Users.one FROM Users AS one, Users AS two, Users AS three, Users AS four, Users AS five, Users AS six)";
                command = new SqlCommand(sqlExpression, connection);
                number += await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
                Console.Read();
     }

        public static async Task SelectorAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var startTime = System.Diagnostics.Stopwatch.StartNew();

                string sqlExpression = "SELECT Sex, FIO  FROM Users WHERE Sex='man' and FIO LIKE 'F%';";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                startTime.Stop();
                var resultTime = startTime.Elapsed;
                Console.WriteLine(String.Format("{0:00}:{1:00}", resultTime.Minutes, resultTime.Seconds));
                Console.WriteLine();
                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);

                    Console.WriteLine($"{columnName1}\t{columnName2}");

                    while (await reader.ReadAsync())
                    {
                        object Sex = reader.GetValue(0);
                        object FIO = reader.GetValue(1);
                        Console.WriteLine($" \t{Sex} \t{FIO}");
                    }
                }

                await reader.CloseAsync();

            }
        }


        public static async Task TableIndexiser(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "CREATE INDEX MyIndex ON Users;";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                }

            }
        }


        

    }

    

