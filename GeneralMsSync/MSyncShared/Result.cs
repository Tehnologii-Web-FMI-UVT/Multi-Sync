namespace CMSShared
{
    public enum EResultStatus : int
    {
        Success = 0,
        Error = 1,
        ObjectCreationFailure,
    }

    public class Result<T>
    {
        public EResultStatus Status { get; set; } = EResultStatus.Success;

        public T? Data { get; set; }

        public string? Message { get; set; }

    }

    public class Result : Result<object>
    {
        public static Result<object> EmptySuccessResponse => new Result<object> { Status = EResultStatus.Success, Data = null, Message = null };

        public static Result<object> EmptyErrorResponse => new Result<object> { Status = EResultStatus.Error, Data = null, Message = null };
    }
}
