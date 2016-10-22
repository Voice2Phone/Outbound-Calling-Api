using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.Responses
{
    public class BaseResponse
    {
        private readonly HttpStatusCode _status;

        private readonly string _message;

        internal BaseResponse(HttpStatusCode status)
        {
            _message = string.Empty;
            _status = status;
        }

        internal BaseResponse(WebException ex)
        {
            string msgError = string.Empty;
            if (ex.Response != null)
            {
                var tmp = ex.Response.GetResponseStream();
                if (tmp != null)
                {
                    StreamReader sr = new StreamReader(tmp);
                    msgError = sr.ReadToEnd();
                }

                var httpWebResponse = ex.Response as HttpWebResponse;

                _message = msgError;
                _status = httpWebResponse.StatusCode;

            }            
        }



        public HttpStatusCode Status 
        { 
            get 
            { 
                return _status; 
            } 
        }

        public string Message 
        {
            get 
            {
                return _message;
            }
        }


        
    }
}
