using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TaturevichBlog.UI.Infrastructure
{
    /// <summary>
    /// Apply Feature Folder conventions for controllers
    /// </summary>
    public class FeatureFolderConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var featureName = GetFeatureName(controller.ControllerType);
            controller.Properties.Add("feature", featureName);
        }

        private static string GetFeatureName(Type controllerType)
        {
            var tokens = controllerType.FullName.Split('.');
            if (tokens.All(t => t != "Features"))
            {
                return string.Empty;

            }
      
            var featureName = tokens
                .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
                .Skip(1)
                .Take(1)
                .FirstOrDefault();

            return featureName;
        }
    }
}
