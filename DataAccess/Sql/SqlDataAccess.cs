using Dapper;
using Microsoft.Data.SqlClient;

namespace DataAccess.Sql;

public class SqlDataAccess 
{
    public IEnumerable<T> ExecuteQuery<T>(string connectionString,
                                          string query,
                                          object? parameters = null,
                                          int? commandTimeout = 60)
    {
        HandleNull(connectionString, query);
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

    public int ExecuteNonQuery(string connectionString,
                               string query,
                               object? parameters = null,
                               int? commandTimeout = 60)
    {
        HandleNull(connectionString, query);
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


    public T? ExecuteScalarAsync<T>(string connectionString,
                                    string query,
                                    object? parameters = null,
                                    int? commandTimeout = 60)
    {
        HandleNull(connectionString, query);
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

    private void HandleNull(string connectionString, string query)
    {
        ArgumentNullException.ThrowIfNull(connectionString);
        ArgumentNullException.ThrowIfNull(query);
    }}


