using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Voice2Phone.Api.JsonDataObject;
using Voice2Phone.Api.Responses;

namespace Voice2Phone.Api
{
   public class Client
   {      
        private static void PrepareHeader(WebRequest request, string secretApiKey)
        {
            request.Headers.Add("Authorization", secretApiKey);
            request.ContentType = "application/json";
        }
       
        public static async Task<MakeCallResponse> MakeCallAsync(
            string secretApiKey, 
            string phoneNumber,
            string countryCode, 
            string message,
            Dictionary<string, string> dtmfs)
        {
            
            
            var request = WebRequest.Create(new Uri("https://api.voice2phone.com/call"));
            request.Method = "POST";
            
            PrepareHeader(request, secretApiKey);
            
            using (var stream = request.GetRequestStream())
            {
                MakeCallJsonRequest jsonDataObj = new MakeCallJsonRequest
                {
                    Phone = new PhoneJsonObject
                    {
                        CountryCode = countryCode,
                        Number = phoneNumber
                    },
                    Message = message,
                    Dtmf = dtmfs
                };

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MakeCallJsonRequest));
                ser.WriteObject(stream, jsonDataObj);
                                
                try
                {
                    using (var response = await request.GetResponseAsync())
                    {
                        using (var responseStream = response.GetResponseStream())
                        {

                            DataContractJsonSerializer desser = new DataContractJsonSerializer(typeof(CallIdJsonResponse));

                            CallIdJsonResponse id = (CallIdJsonResponse)desser.ReadObject(responseStream);

                            return new MakeCallResponse(id.CallId);
                        }
                    }

                }
                catch (WebException ex)
                {
                    return new MakeCallResponse(ex);
                }
            
            }

        }


        public static async Task<GetStatusResponse> GetStatusAsync(
            string secretApiKey, 
            Guid callId)
        {

            var request = WebRequest.Create(new Uri(string.Format("https://api.voice2phone.com/call/{0}", callId)));
            request.Method = "GET";
            PrepareHeader(request, secretApiKey);

            
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        DataContractJsonSerializer desser = new DataContractJsonSerializer(typeof(CallStatusJsonResponse));

                        CallStatusJsonResponse callStatusJsonResponse = (CallStatusJsonResponse)desser.ReadObject(responseStream);

                        return new GetStatusResponse(callStatusJsonResponse.CallId, callStatusJsonResponse.Status, DateTime.Parse(callStatusJsonResponse.CreatedDateUtc), DateTime.Parse(callStatusJsonResponse.UpdatedDateUtc), callStatusJsonResponse.Dtmf);
                    }
                }
            }
            catch (WebException ex)
            {
                return new GetStatusResponse(ex);
            }

            
        }
    }
}
