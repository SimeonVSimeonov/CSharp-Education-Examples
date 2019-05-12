using System;
using System.Collections.Generic;
using System.Text;

namespace CakesWebApp.Services.Contracts
{
    public interface IUserCookieService
    {
        string GetUserCookie(string userName);

        string GetUserData(string cookieContent);
    }
}
