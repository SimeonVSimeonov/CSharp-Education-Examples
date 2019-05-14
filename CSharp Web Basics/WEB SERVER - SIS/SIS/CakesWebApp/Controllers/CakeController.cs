using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace CakesWebApp.Controllers
{
    public class CakeController : BaseController
    {
        public IHttpResponse AddCakeView(IHttpRequest request)
        {
            return this.View("AddCake");
        }
    }
}
