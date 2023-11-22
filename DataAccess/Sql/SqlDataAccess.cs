using Dapper;
using Microsoft.Data.SqlClient;

namespace DataAccess.Sql;

public class SqlDataAccess : ISqlDataAccess1
{
    public IEnumerable<T> ExecuteQuery<T>(string? query,
                                                            object? parameters = null,
                                                            string? connectionString = null,
                                                            int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            return connection.Query<T>(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public int ExecuteNonQuery(string? query,
                                                object? parameters = null,
                                                string? connectionString = null,
                                                int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            return connection.Execute(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }


    public T? ExecuteScalarAsync<T>(string? query,
                                            object? parameters = null,
                                            string? connectionString = null,
                                            int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            var result = connection.ExecuteScalar<T>(command);
            return result != null ? result : default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}


