using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniHttpServer
{
    public interface IHttpServer
    {
        void Start();

        void Stop();
    }
}
