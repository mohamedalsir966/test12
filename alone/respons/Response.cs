using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace alone.respons
{
    public class Response 
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
