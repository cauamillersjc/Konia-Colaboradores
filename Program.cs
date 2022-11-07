using System;
using System.Data.SqlClient;

namespace EmployeeInserter
{
    internal class Program
    {
        static SqlConnection connection;
        static readonly List<string> employees = new List<string>(new string[] { "José", "Maria", "João", "Ana", "Antonio", "Aline", "Francisco", "Adriana", "Carlos", "Juliana" });

        static void Main(string[] args)
        {
            Console.WriteLine("Configurando conexão ao Banco de Dados ...");

            var datasource = @"ITANBT012\SQLEXPRESS"; // Servidor
            var database = "db_colaboradores"; // Nome do Banco de Dados
            var username = "sa"; // Usuário de conexão com o Banco de Dados
            var password = "q1w2e3r4"; // Senha de conexão com o Banco de Dados

            // String de conexão com o Banco de Dados
            string connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            connection = new SqlConnection(connectionString);

            try
            {
                Console.WriteLine("Conectando com o Banco de Dados ...");

                connection.Open();

                Console.WriteLine("Conectado com sucesso!");

                foreach(var employee in employees)
                {
                    InsertEmployee(employee);
                }

                connection.Close();

                Console.ReadKey();
            } 
            catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        static void InsertEmployee(string name)
        {
            string sqlQuery = $"INSERT INTO colaboradores (nome) VALUES ('{name}')";

            using(SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine(name + " inserido no Banco de Dados com sucesso!");
            }
        }
    }
}