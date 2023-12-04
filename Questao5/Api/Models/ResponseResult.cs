namespace Questao5.Api.Models
{
    public class ResponseResult : ResponseResult<object>
    {
    }

    public class ForbiddenResponseResult : ForbiddenResponseResult<object>
    {
    }

    public class BadResponseResult : BadResponseResult<object>
    {
    }

    public class ResponseResult<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<string> Notifications { get; set; } = new List<string>();
    }

    public class ForbiddenResponseResult<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<string> Notifications { get; set; } = new List<string>();
    }

    public class BadResponseResult<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<string> Notifications { get; set; } = new List<string>();
    }
}
