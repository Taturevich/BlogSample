using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TaturevichBlog.UI.Infrastructure
{
    public class FeatureFolderViewLocator : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (viewLocations == null)
            {
                throw new ArgumentNullException(nameof(viewLocations));
            }

            if (!(context.ActionContext.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor))
            {
                throw new NullReferenceException("ControllerActionDescriptor cannot be null.");
            }

            var featureName = controllerActionDescriptor.Properties["feature"] as string;
            foreach (var location in viewLocations)
            {
                var completeLocation = location.Replace("{2}", featureName);
                yield return completeLocation;
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}
