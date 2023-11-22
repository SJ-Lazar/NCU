using Dapper;
using Microsoft.Data.SqlClient;

namespace DataAccess.Sql;

public class SqlDataAccessAsync : ISqlDataAccess
{
    public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string? query,
                                                            object? parameters = null,
                                                            string? connectionString = null,
                                                            int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
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

    public async Task<int> ExecuteNonQueryAsync(string? query,
                                                object? parameters = null,
                                                string? connectionString = null,
                                                int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
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


    public async Task<T?> ExecuteScalarAsync<T>(string? query,
                                            object? parameters = null,
                                            string? connectionString = null,
                                            int? commandTimeout = 60)
    {
        ArgumentNullException.ThrowIfNull(query);
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
}


