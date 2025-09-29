namespace _001_VMT.Shared.Helpers.Models;

public class ApiResponse<T>
(
    bool success,
    int statusCode,
    string statusText,
    string message,
    T data
)
{
    public bool Success { get; set; } = success;
    public int StatusCode { get; set; } = statusCode;
    public string StatusText { get; set; } = statusText;
    public string Message { get; set; } = message;
    public T Data { get; set; } = data;
}