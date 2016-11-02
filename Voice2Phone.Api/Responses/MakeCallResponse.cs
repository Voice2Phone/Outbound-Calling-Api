using System;
using System.Net;

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
