namespace Felice.Mvc
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Core;

    public class StructureMapFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        protected override IEnumerable<FilterAttribute> GetControllerAttributes(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetControllerAttributes(controllerContext, actionDescriptor);

            foreach (var attr in attributes)
            {
                Dependency.BuildUp(attr);
            }

            return attributes;
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetActionAttributes(controllerContext, actionDescriptor);

            foreach (var attr in attributes)
            {
                Dependency.BuildUp(attr);
            }

            return attributes;
        }
    }
}
