using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestApiZoom.Models;

namespace TestApiZoom.JWT.Zoom
{
    public class ZoomAPI
    {

        public ZoomAPI()
        {
            this.GenerateToken();
        }

        private string API_KEY
        {
            get
            {
                return "API_KEY";
            }
        }

        private string API_SECRET
        {
            get
            {
             
               return "API_SECRET";
            }
        }


        private string URL_BASE
        {
            get
            {
                return "https://api.zoom.us/v2/";
            }

        }

        private string USER_ID
        {
            get { return "USER_ID"; }
        }

        public JsonWebToken Token { get; private set; }
        

        public void GenerateToken()
        {
          
            JsonWebTokenBuilder builder = new JsonWebTokenBuilder();
            var header = new Header();//instanciado com os valores padrão.
            var payload = new PayloadResponse()
            {
                api_key = API_KEY,
                expireDate = Convert.ToInt32(DateTime.UtcNow.AddMinutes(30).Subtract(new DateTime(1970, 1, 1)).TotalSeconds),
            };

            builder.AddHeader("alg", header.alg);
            builder.AddHeader("typ", header.typ);

            builder.AddClaim("exp", payload.expireDate);
            builder.AddClaim("iss", payload.api_key);

            this.Token = builder.GetJWT(API_SECRET);
        }

        public object GetUsers()
        {
            string baseURL = URL_BASE + "users";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token.GetJWT());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseURL).Result;

                response.EnsureSuccessStatusCode();
                string conteudo = response.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(conteudo);

                return result;

            }
        }

        public Meeting CreateMeeting(string topic)
        {

            string baseURL = URL_BASE + "users/" + USER_ID + "/meetings";

            Meeting metting = new Meeting(topic);
            string postBody = JsonConvert.SerializeObject(metting);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token.GetJWT());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
                HttpResponseMessage response = client.PostAsync(baseURL, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;

                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;
                
                Meeting meetingReturn = JsonConvert.DeserializeObject<Meeting>(content);

                return meetingReturn;
            }

        }

        public Meetings ListMeetings()
        {
            string baseURL = URL_BASE + "users/" + USER_ID + "/meetings";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token.GetJWT());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseURL).Result;

                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;

                Meetings meetings = JsonConvert.DeserializeObject<Meetings>(content);

                return meetings;

            }
        }

    }
}