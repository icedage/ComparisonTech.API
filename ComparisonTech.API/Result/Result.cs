using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonTech.API.Result
{
    public abstract class Result<T>
    {
        public abstract T Value { get; }
        public abstract ErrorMessage Error { get; }
        public abstract int StatusCode { get; }
        public bool IsSuccessful => StatusCode >= 200 && StatusCode < 300;
    }
}
