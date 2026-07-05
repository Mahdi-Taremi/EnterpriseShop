using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        public T? Data { get; init; }

        public IEnumerable<string>? Errors { get; init; }

        public static ApiResponse<T> Ok(
            T data,
            string message = "")
        {
            return new()
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Fail(
            IEnumerable<string> errors,
            string message = "")
        {
            return new()
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
