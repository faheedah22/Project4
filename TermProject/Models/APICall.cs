using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;


namespace TermProject.Models
{
    public class APICall
    {
       // private readonly string apiURL= "https://localhost:7158/"; use this for local host
       // string apiURL = "https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/";


        public string GetApiPOST(string route, Object obj)
        {
            try
            {
                String json = JsonConvert.SerializeObject(obj);
                // WebRequest request = WebRequest.Create(apiURL + route);//use for local host
                WebRequest request = WebRequest.Create(route);


                request.Method = "POST";
                request.ContentLength = json.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(json);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return data;
            }
            catch
            {
                return null;
            }
        }

        public string GetApiPUT(string route, Object obj)
        {
            try
            {
                String json = JsonConvert.SerializeObject(obj);
                //WebRequest request = WebRequest.Create(apiURL + route); //use this for local host

                WebRequest request = WebRequest.Create(route);

                request.Method = "PUT";
                request.ContentLength = json.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(json);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return data;
            }
            catch
            {
                return null;
            }
        }

        public string GetApiGet(string route)
        {
            
            try
            {
                //WebRequest request = WebRequest.Create(apiURL + route); //use this for local host
                WebRequest request = WebRequest.Create(route);

               

                WebResponse response = request.GetResponse();


                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                var data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                return data;
            }
            catch
            {
                return null;
            }
        }

        public string GetApiDelete(string route)
        {
           
            try
            {
                // WebRequest request = WebRequest.Create(apiURL + route); //use this for local host
                WebRequest request = WebRequest.Create(route);
                request.Method = "DELETE";
             


                WebResponse response = request.GetResponse();


                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                var data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                return data;
            }
            catch
            {
                return null;
            }
        }

    }
}
