using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Put your Connection String here";
        string storedProcedureName = "RunningProcedure";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Registrar o evento para capturar as mensagens
                connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    Console.WriteLine("Calling the stored procedure...");

                    // Executar a stored procedure (essa chamada é síncrona).
                    command.ExecuteNonQuery();

                    Console.WriteLine("Stored procedure finished.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }

    // Manipulador de eventos para capturar mensagens enviadas com RAISERROR ou PRINT
    static void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        // Exibir as mensagens de progresso da stored procedure
        Console.WriteLine("Message from SQL Server: " + e.Message);
    }
}
