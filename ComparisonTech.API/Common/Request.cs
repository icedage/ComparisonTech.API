using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonTech.API.Common
{
    public abstract class Request
    {
        protected internal string AnonymousTrackingId { get; set; }
    }
}
