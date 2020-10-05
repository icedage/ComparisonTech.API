using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonTech.API.Result
{
    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult(T value)
        {
            Value = value;
        }
        public override int StatusCode => 200;
        public override T Value { get; }
        public override ErrorMessage Error { get; }
    }
}
