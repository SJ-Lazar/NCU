using Dapper;
using Microsoft.Data.SqlClient;

namespace DataAccess.Sql;

public class SqlDataAccessAsync 
{
    public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string connectionString,
                                                           string query,
                                                           object? parameters = null,
                                                           int? commandTimeout = 60)
    {
        HandleNullQuery(query, connectionString);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            return await connection.QueryAsync<T>(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public async Task<int> ExecuteNonQueryAsync(string connectionString,
                                                string query,
                                                object? parameters = null,
                                                int? commandTimeout = 60)
    {
        HandleNullQuery(query, connectionString);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            return await connection.ExecuteAsync(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }


    public async Task<T?> ExecuteScalarAsync<T>(string connectionString,
                                                string query,
                                                object? parameters = null,
                                                int? commandTimeout = 60)
    {
        HandleNullQuery(query, connectionString);
        using var connection = new SqlConnection(connectionString);
        try
        {
            var command = new CommandDefinition(query, parameters, commandTimeout: commandTimeout);
            var result = await connection.ExecuteScalarAsync<T>(command);
            return result != null ? result : default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    private static void HandleNullQuery(string query, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(connectionString);
    }
}


