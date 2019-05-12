using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View("Index");
        }

        public IHttpResponse Hello(IHttpRequest request)
        {
            return new HtmlResult($"<h1>Hello, {this.GetUser(request)}</h1>", HttpResponseStatusCode.OK);
        }
    }
}
