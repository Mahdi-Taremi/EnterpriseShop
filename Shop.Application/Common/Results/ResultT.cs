using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Results
{
    public sealed class Result<T> : Result
    {
        public T? Value { get; }

        private Result(
            T? value,
            bool isSuccess,
            string? error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
            => new(value, true, null);

        public new static Result<T> Failure(
            string error)
            => new(default, false, error);
    }
}
