using SIS.HTTP.Enums;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;
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

        private string GetCurrentControllerName() =>
            this.GetType().Name.Replace(ControllerDefaultName, "");

        //protected IHttpResponse View(string viewName)
        //{
        //    var content = File.ReadAllText("Views/Home/" + viewName + ".html");
        //    return new HtmlResult(content, HttpResponseStatusCode.OK);
        //}

        //protected IHttpResponse ViewLoginRegister(string viewName)
        //{
        //    var content = File.ReadAllText("Views/Users/" + viewName + ".html");
        //    return new HtmlResult(content, HttpResponseStatusCode.OK);
        //}

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
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

            var fileContent = File.ReadAllText(filePath);

            var response = new HtmlResult(fileContent, HttpResponseStatusCode.OK);

            return response;

        }
    }
}
