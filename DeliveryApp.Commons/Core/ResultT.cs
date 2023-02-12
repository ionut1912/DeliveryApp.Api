namespace DeliveryApp.Commons.Core;

public class ResultT<T>
{
    public bool IsSuccess { get; set; }
    public T Value { get; set; }
    public string Error { get; set; }

    public static ResultT<T> Success(T value)
    {
        return new ResultT<T> { IsSuccess = true, Value = value };
    }

    public static ResultT<T> Failure(string error)
    {
        return new ResultT<T> { IsSuccess = false, Error = error };
    }
}