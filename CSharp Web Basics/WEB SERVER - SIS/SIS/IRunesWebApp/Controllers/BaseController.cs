using IRunesWebApp.Data;
using IRunesWebApp.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace IRunesWebApp.Controllers
{
    public abstract class BaseController
    {
        private const string RelativePath = "../../../";

        private const string ControllerDefaultName = "Controller";

        private const string DirectorySeparator = "/";

        private const string ViewsFolderName = "Views";

        private const string HtmlFileExtension = ".html";

        private const string LayoutViewFileName = "_Layout";

        private const string RenderBodyConstant = "@RenderBody()";

        protected IRunesDbContext Context { get; set; }

        private readonly UserCookieService userCookieService;

        protected IDictionary<string, string> ViewBag { get; set; }

        public BaseController()
        {
            this.Context = new IRunesDbContext();
            this.userCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        private string GetCurrentControllerName() =>
            this.GetType().Name.Replace(ControllerDefaultName, "");

        public void SignInUser(string username, IHttpResponse response, IHttpRequest request)
        {
            request.Session.AddParameter("username", username);
            var userCookieValue = this.userCookieService.GetUserCookie(username);
            response.Cookies.Add(new HttpCookie("IRunes_auth", userCookieValue));
        }

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            var layoutView = RelativePath +
                                ViewsFolderName +
                                DirectorySeparator +
                                LayoutViewFileName +
                                HtmlFileExtension;

            string filePath = RelativePath +
                                ViewsFolderName +
                                DirectorySeparator +
                                this.GetCurrentControllerName() +
                                DirectorySeparator +
                                viewName +
                                HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                return new BadRequestResult(
                    $"View {viewName} not found.",
                    HttpResponseStatusCode.NotFound);
            }

            var viewContent = BuildViewContent(filePath);

            var viewLayout = File.ReadAllText(layoutView);

            var view = viewLayout.Replace(RenderBodyConstant, viewContent);

            var response = new HtmlResult(view, HttpResponseStatusCode.OK);

            return response;

        }

        private string BuildViewContent(string filePath)
        {
            var viewContent = File.ReadAllText(filePath);

            foreach (var viewBagKey in ViewBag.Keys)
            {
                var dynamicDataPlaceholder = $"{{{{{viewBagKey}}}}}";

                if (viewContent.Contains(dynamicDataPlaceholder))
                {
                    viewContent = viewContent.Replace(dynamicDataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return viewContent;
        }
    }
}
