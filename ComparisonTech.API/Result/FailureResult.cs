using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonTech.API.Result
{
    public class FailureResult<T> : Result<T>
    {
        public FailureResult(ErrorMessage message)
        {
            Error = message;
        }
        public override ErrorMessage Error { get; }
        public override int StatusCode => 500;
        public override T Value => default(T);
    }
}
