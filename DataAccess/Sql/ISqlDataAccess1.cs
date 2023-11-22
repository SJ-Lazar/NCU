
namespace DataAccess.Sql
{
    public interface ISqlDataAccess1
    {
        int ExecuteNonQuery(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
        IEnumerable<T> ExecuteQuery<T>(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
        T? ExecuteScalarAsync<T>(string? query, object? parameters = null, string? connectionString = null, int? commandTimeout = 60);
    }
}