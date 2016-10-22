using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.JsonDataObject
{
    [DataContract]
    class CallStatusJsonResponse
    {
        [DataMember]
        public Guid CallId { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string CreatedDateUtc { get; set; }

        [DataMember]
        public string UpdatedDateUtc { get; set; }
        [DataMember]
        public string Dtmf { get; set; }
    }
}
