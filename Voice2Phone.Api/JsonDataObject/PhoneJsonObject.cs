using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voice2Phone.Api.JsonDataObject
{
    [DataContract]
    internal class PhoneJsonObject
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

    }
}
