using IRunesWebApp.Services;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using IRunesWebApp.Models;
using IRunesWebApp.Data;
using System.Linq;
using SIS.WebServer.Results;
using SIS.HTTP.Enums;
using System;

namespace IRunesWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly HashService hashService;

        public UsersController()
        {
            this.hashService = new HashService();
        }
        public IHttpResponse Login(IHttpRequest request) => this.View("Login");
        public IHttpResponse PostLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString();
            var password = request.FormData["password"].ToString();

            var hashedPass = this.hashService.Hash(password);

            var user = this.Context.Users.FirstOrDefault(x => x.Username == username &&
                x.HashedPassword == hashedPass);

            if (user == null)
            {
                return new RedirectResult("/login");
            }

            var response = new RedirectResult("/home/index");
            this.SignInUser(username, response, request);
            return response;
        }

        public IHttpResponse Register(IHttpRequest request) => this.View("Register");
        public IHttpResponse PostRegister(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (password != confirmPassword)
            {
                return new BadRequestResult(
                    "Passwords do not match.",
                    HttpResponseStatusCode.SeeOther);
            }

            var hashedPass = this.hashService.Hash(password);

            var user = new User { Username = username, HashedPassword = hashedPass };

            this.Context.Users.Add(user);

            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                return new BadRequestResult(e.Message, HttpResponseStatusCode.InternalServerError);
            }

            var response = new RedirectResult("/");
            this.SignInUser(username, response, request);

            return response;
        }
    }
}
