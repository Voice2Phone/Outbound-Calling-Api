using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.Responses
{
    public class MakeCallResponse : BaseResponse
    {
        private Guid _callId;
        
        public MakeCallResponse(Guid callId) : base(HttpStatusCode.OK)
        {
            _callId = callId;
        }


        public MakeCallResponse(WebException ex): base(ex)
        {

        }



        
        public Guid CallId 
        {
            get { return _callId; }
        }

    }
}
