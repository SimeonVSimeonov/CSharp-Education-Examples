using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace IRunesWebApp.Controllers
{
    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest request) => this.ViewLoginRegister("Login");
        public IHttpResponse Register(IHttpRequest request) => this.ViewLoginRegister("Register");
    }
}
