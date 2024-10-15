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
                // Register the event to capture messages
                connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    Console.WriteLine("Calling the stored procedure...");

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    Console.WriteLine("Stored procedure finished.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Event handler to capture messages sent with RAISERROR or PRINT
    static void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        // Display the progress messages from the stored procedure
        Console.WriteLine("Message from SQL Server: " + e.Message);
    }
}
