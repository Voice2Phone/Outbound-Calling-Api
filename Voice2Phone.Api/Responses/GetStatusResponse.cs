using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.Responses
{
    public class GetStatusResponse : BaseResponse
    {

        private readonly Guid _callId;

        private readonly int _status;

        private readonly DateTime _createDate;

        private readonly DateTime _updatedDate;

        private readonly string _dtmf;

        public Guid CallId
        {
            get { return _callId; }
        }

        
        public int CallStatus
        {
            get { return _status; }
        }
     

        public DateTime CreatedDateUtc 
        {
            get { return _createDate; }
        }


        public DateTime UpdatedDateUtc 
        {
            get { return _updatedDate; }
        }

        public string Dtmf 
        {
            get { return _dtmf; }
        }

        internal GetStatusResponse(Guid callId, int status, DateTime createdDateUtc, DateTime updateddDateUtc, string dtmf)
            : base(System.Net.HttpStatusCode.OK)
        {
            _callId = callId;
            _status = status;
            _createDate = createdDateUtc;
            _updatedDate = updateddDateUtc;
            _dtmf = dtmf;
        }

        internal GetStatusResponse(WebException ex)
            : base(ex)
        {

        }
    }
}
