using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace ComparisonTech.API.Infrastructure
{
    public class AnonymousUserTrackingModelConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (IsAllowAnonymousAction(action))
                action.Filters.Add(new AnonymousUserTrackingFilter());
        }

        private bool IsAllowAnonymousAction(ICommonModel action)
        {
            return action.Attributes.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
        }
    }
}
