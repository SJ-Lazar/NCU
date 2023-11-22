using System.Collections.Generic;

namespace Domain.Wrappers;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int? StatusCode { get; set; }
    public ApiError? Error { get; set; }
    public Dictionary<string, string>? Errors { get; set; }
}
