using System.Reflection;

using MyWebServer.Http;
using MyWebServer.Results;
using MyWebServer.Routing.Contracts;

namespace MyWebServer.Controllers
{
    public static class RoutingTableExtensions
    {
        private static Type actionResultType = typeof(ActionResult);
        private static Type stringType = typeof(string);

        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunc)
            where TController : Controller
            => routingTable.MapGet(path, request => controllerFunc(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunc)
            where TController : Controller
            => routingTable.MapPost(path, request => controllerFunc(CreateController<TController>(request)));

        public static IRoutingTable MapControllers(this IRoutingTable routingTable)
        {
            var controllerActions = GetControllerActions();

            foreach (var controllerAction in controllerActions)
            {
                var controllerType = controllerAction.DeclaringType;
                var controllerName = controllerType.GetControllerName();
                var actionName = controllerAction.Name;

                var path = $"/{controllerName}/{actionName}";

                var responseFunc = GetResponseFunction(controllerType, controllerAction, path);

                var httpMethod = Http.Enums.HttpMethod.GET;
                var httpMethodAttribute = controllerAction.GetCustomAttribute<HttpMethodAttribute>();

                if (httpMethodAttribute != null)
                {
                    httpMethod = httpMethodAttribute.HttpMethod;
                }

                routingTable.Map(httpMethod, path, responseFunc);

                MapDefaultRoutes(routingTable, httpMethod, controllerName, actionName, responseFunc);
            }

            return routingTable;
        }

        private static IEnumerable<MethodInfo> GetControllerActions()
            => Assembly
                .GetEntryAssembly()
                .GetExportedTypes()
                .Where(t => !t.IsAbstract
                    && t.IsAssignableTo(typeof(Controller))
                    && t.Name.EndsWith(nameof(Controller)))
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.ReturnType.IsAssignableTo(actionResultType)))
                .ToList();

        private static Func<HttpRequest, HttpResponse> GetResponseFunction(Type controllerType, MethodInfo controllerAction, string path)
            => request =>
            {
                if (!IsUserAuthorized(controllerAction, request.Session))
                {
                    return new HttpResponse(Http.Enums.HttpStatusCode.Unauthorized);
                }

                var controllerInstance = CreateController(controllerType, request);

                if (controllerAction.ReturnType != actionResultType)
                {
                    throw new InvalidOperationException($"Controller action '{path}' does not return an ActionResult object.");
                }

                var parameterValues = GetParameterValues(controllerAction, request);

                return (ActionResult)controllerAction.Invoke(controllerInstance, parameterValues);
            };

        private static object CreateController(Type controllerType, HttpRequest request)
        {
            var controller = (Controller)request.Services.CreateInstance(controllerType);

            controllerType.GetProperty("Request", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(controller, request);

            return controller;
        }

        private static TController CreateController<TController>(HttpRequest request)
            where TController : Controller
            => (TController)CreateController(typeof(TController), request);

        private static void MapDefaultRoutes(IRoutingTable routingTable, Http.Enums.HttpMethod httpMethod, string controllerName, string actionName, Func<HttpRequest, HttpResponse> responseFunc)
        {
            const string defaultActionName = "Index";
            const string defaultControllerName = "Home";

            if (actionName == defaultActionName)
            {
                routingTable.Map(httpMethod, $"/{controllerName}", responseFunc);

                if (controllerName == defaultControllerName)
                {
                    routingTable.Map(httpMethod, "/", responseFunc);
                }
            }
        }

        private static bool IsUserAuthorized(MethodInfo controllerAction, HttpSession session)
        {
            var authorizationRequired = controllerAction.DeclaringType.GetCustomAttribute<AuthorizeAttribute>()
                    ?? controllerAction.GetCustomAttribute<AuthorizeAttribute>();

            if (authorizationRequired != null)
            {
                var userIsAuthenticated = session.ContainsKey(Controller.UserSessionKey) &&
                    session[Controller.UserSessionKey] != null;

                if (!userIsAuthenticated)
                {
                    return false;
                }
            }

            return true;
        }

        private static object[] GetParameterValues(MethodInfo controllerAction, HttpRequest request)
        {
            var actionParameters = controllerAction
                    .GetParameters()
                    .Select(p => new
                    {
                        p.Name,
                        Type = p.ParameterType,
                    })
                    .ToArray();

            var parameterValues = new object[actionParameters.Length];
            for (int i = 0; i < actionParameters.Length; i++)
            {
                var parameterName = actionParameters[i].Name;
                if (actionParameters[i].Type.IsPrimitive || actionParameters[i].Type == stringType)
                {
                    var parameterValue = request.GetValue(parameterName.ToLower());

                    parameterValues[i] = Convert.ChangeType(parameterValue, actionParameters[i].Type);
                }
                else
                {
                    var complexParameterValue = Activator.CreateInstance(actionParameters[i].Type);
                    var complexParameterProperties = actionParameters[i].Type.GetProperties();

                    foreach (var property in complexParameterProperties)
                    {
                        var propertyValue = request.GetValue(property.Name.ToLower());

                        property.SetValue(complexParameterValue, Convert.ChangeType(propertyValue, property.PropertyType));
                    }

                    parameterValues[i] = complexParameterValue;
                }
            }

            return parameterValues;
        }

        private static object GetValue(this HttpRequest request, string parameterName)
            => request.Query.GetValueOrDefault(parameterName)
                ?? request.Form.GetValueOrDefault(parameterName);
    }
}