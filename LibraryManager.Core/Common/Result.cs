using System.Runtime.InteropServices.JavaScript;

namespace LibraryManager.Core.Common;

public class Result<T>
{
  public bool IsSuccess { get; set; }
  public T? Value { get; set; }
  public string? ErrorMessage { get; set; }

  private Result(bool isSuccess, T? value, string errorMessage)
  {
    isSuccess = isSuccess;
    value = value;
    ErrorMessage = errorMessage;
  }
  
  public static Result<T> Success(T value) => new Result<T>(true, value, null);
  public static Result<T> Failure(string message) => new Result<T>(false, default, message);
}