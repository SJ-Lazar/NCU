
namespace DataAccess.Sql
{
    public interface ISqlDataAccess
    {
        Task<int> ExecuteNonQueryAsync(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
        Task<T?> ExecuteScalarAsync<T>(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
    }
}