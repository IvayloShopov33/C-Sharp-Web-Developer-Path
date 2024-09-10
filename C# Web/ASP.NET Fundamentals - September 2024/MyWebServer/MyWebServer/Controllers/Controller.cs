using System.Runtime.CompilerServices;

using MyWebServer.Http;
using MyWebServer.Http.Enums;
using MyWebServer.Identity;
using MyWebServer.Results;
using MyWebServer.Results.Views.Contracts;
using MyWebServer.Results.Views;

namespace MyWebServer.Controllers
{
    public abstract class Controller
    {
        public const string UserSessionKey = "AuthenticatedUserId";

        private UserIdentity userIdentity;
        private IViewEngine viewEngine;

        protected HttpRequest Request { get; init; }

        protected HttpResponse Response { get; private init; } = new HttpResponse(HttpStatusCode.OK);

        protected UserIdentity User
        {
            get
            {
                if (this.userIdentity == null)
                {
                    this.userIdentity = this.Request.Session.ContainsKey(UserSessionKey)
                        ? new UserIdentity { Id = this.Request.Session[UserSessionKey] }
                        : new();
                }

                return this.userIdentity;
            }
        }

        protected IViewEngine ViewEngine
        {
            get
            {
                if (this.viewEngine == null)
                {
                    this.viewEngine = this.Request.Services.GetService<IViewEngine>()
                        ?? new CompilationViewEngine();
                }

                return this.viewEngine;
            }
        }

        protected void SignIn(string userId)
        {
            this.Request.Session[UserSessionKey] = userId;
            this.userIdentity = new UserIdentity
            {
                Id = userId,
            };
        }

        protected void SignOut()
        {
            this.Request.Session.Remove(UserSessionKey);
            this.userIdentity = new UserIdentity();
        }

        protected ActionResult Text(string text)
            => new TextResult(this.Response, text);

        protected ActionResult Html(string html)
            => new HtmlResult(this.Response, html);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response, location);

        protected ActionResult Unauthorized()
            => new UnauthorizedResult(this.Response);

        protected ActionResult Error(string error)
            => this.Error(new[] { error });

        protected ActionResult Error(IEnumerable<string> errors)
            => this.View("/Shared/Error", errors);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, this.ViewEngine, viewName, this.GetType().GetControllerName(), null, this.User.Id);

        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response, this.ViewEngine, viewName, this.GetType().GetControllerName(), model, this.User.Id);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, this.ViewEngine, viewName, this.GetType().GetControllerName(), model, this.User.Id);
    }
}