using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Extensions; 
public static class IUrlHelperExtensions {
    public static string MakeActiveClass(this IUrlHelper urlHelper, string controller, string action) {

		try {

			var result = "active";
			var controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
			var actionName = urlHelper.ActionContext.RouteData.Values["action"].ToString();

			if (string.IsNullOrEmpty(controllerName) || string.IsNullOrEmpty(controller))
				return null;

			var actions = action.Split(", ")?.ToList().Select(x => x.ToUpper());

			if (controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase)) {

				if (actions.Contains(actionName.ToUpper()))
					return result;
			}

			return null;
		}
		catch (Exception) {

			return null;
		}
    } 
}
