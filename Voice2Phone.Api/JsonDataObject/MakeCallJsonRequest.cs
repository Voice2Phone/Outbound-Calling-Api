using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.JsonDataObject
{
    [DataContract]
    internal class MakeCallJsonRequest
    {
        [DataMember]
        public PhoneJsonObject Phone { get; set; }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Dictionary<string, string> Dtmf { get; set; }
    }
}
