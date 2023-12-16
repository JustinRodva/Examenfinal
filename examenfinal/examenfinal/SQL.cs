using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "tu_cadena_de_conexion";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Llamar al procedimiento almacenado para agregar una encuesta
            using (SqlCommand command = new SqlCommand("AgregarEncuesta", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", "NombreEjemplo");
                command.Parameters.AddWithValue("@Edad", 25);
                command.Parameters.AddWithValue("@CorreoElectronico", "correo@example.com");
                command.Parameters.AddWithValue("@PartidoPolitico", "PAC");

                command.ExecuteNonQuery();
            }

            // Llamar al procedimiento almacenado para obtener un reporte de todas las encuestas
            using (SqlCommand command = new SqlCommand("ObtenerReporteEncuestas", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"NumeroEncuesta: {reader["NumeroEncuesta"]}, Nombre: {reader["Nombre"]}, Edad: {reader["Edad"]}, Correo: {reader["CorreoElectronico"]}, Partido: {reader["PartidoPolitico"]}");
                    }
                }
            }
        }
    }
}
