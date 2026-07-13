using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Results
{
    public sealed class Result<T> : Result
    {
        internal Result(
            T? value,
            bool isSuccess,
            Error error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public T? Value { get; }
    }
}
