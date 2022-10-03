using System.Data.SqlClient;
using NPMTK;

namespace NPMTK
{
    internal class TableController
    {


        public async Task CreateTableAsync(string connectionString)
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

        public async Task AddToTableAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Введите ФИО:");
                string? FIO = Console.ReadLine();
                Console.WriteLine("Введите возраст:");
                int Date = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите возраст:");
                string? Sex = Console.ReadLine();
                string sqlExpression = $"INSERT INTO Users (FIO, Date, Sex) VALUES ({FIO}, {Date}, {Sex})";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
            Console.Read();
        }

        public async Task SortUnicValuesTabeAsync(string connectionString)
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

        public async Task AddToTable100500ValuesAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string? FIO = Console.ReadLine();
                int Date = Int32.Parse(Console.ReadLine());
                string? Sex = Console.ReadLine();
                string sqlExpression = $"INSERT INTO Users (FIO, Date, Sex) VALUES (Fanar Abab Baba, 2022-10-10, man),(Jafna Huafna Dudu, 2022-10-10, not), (Call Me Peep, 2022-10-10, man)";
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

    }

    }

