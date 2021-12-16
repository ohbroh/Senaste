/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  UapiREST is a new server process
 *	Remember that a:C85041.AnaplanReAccnt must not be longer than 25 characters
 *                aaaaaaaaaaaaaaaaaaaaaaaaa (this is 25 characters)
 *	and that the dll-file must be physiacally in the Bin-directory if it is used in 553
 *	in 56* you should use Always database instead.
 *    
 *  CREATED:
 *      2021-12-15
 *      William Berglund <william.berglund@konsultnet.se>
 *    
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Agresso.Interface.CommonExtension;
using Agresso.ServerExtension;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UapiREST
{
    [ServerProgram("ACT_PROG")]
    public class Class1 : IServerProgram
    {
        private IReport m_Report;
        /// <summary>
        /// Constructor
        /// </summary>
        public Class1()
        {
            // Avoid using Agresso objects here.
        }
        #region IServerProgram Members
        public void End()
        {
            ServerAPI.Current.WriteLog("end");
            // Place End code here
        }
        public void Initialize(IReport report)
        {
            // ServerAPI.Current.WriteLog("Starta rapport för GL07");
            // Save reference to IReport object
            m_Report = report;
        }
        public void Run()
        {
            ServerAPI.Current.WriteLog("************** RUN START *****************");
            var tsk = RunAsync1();
            tsk.Wait();

           foreach(var x1 in tsk.Result)
            {
                ServerAPI.Current.WriteLog(x1.companyId);
            }
            ServerAPI.Current.WriteLog("************** RUN END *****************");

            string companyid = "";
            string clientName = "";
            string extra_kolumn = "";
            var csv = new StringBuilder();
            string filePath = @"C:\test\testcsv12345.csv";
            foreach (var x1 in tsk.Result)
            {
                companyid = x1.companyId;
                clientName = x1.companyName;
                extra_kolumn = x1.companyName + " - ********** litet tillägg *********";
                var newLine = $"{companyid};{clientName};{extra_kolumn}";
                csv.AppendLine(newLine);
            }
            File.WriteAllText(filePath, csv.ToString());
        }
        public async Task<List<Class12>> RunAsync1()
        {
            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("sysse:sysse");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json-patch+json"));
            string url2 = "http://localhost/wibetest-web-api/v1/objects/companies";

            using (HttpResponseMessage respons = await  client.GetAsync(url2))
            {
                if (respons.IsSuccessStatusCode)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var jsonResponse = await respons.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<Class12>>(jsonResponse);
                    //Console.WriteLine(ro.outputparameters[0].value.array.elements[0]._string.value);
                    //return rootobject;
                    //var jsonList = serializer.Deserialize<Rootobject>(jsonResponse);
                    //var ro = JsonConvert.DeserializeObject<Rootobject>(jsonResponse);
                    //List<Rootobject> myDeserializedObjList = (List<Rootobject>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse, typeof(List<Rootobject>));
                    return results;
                }
                else
                {
                    throw new Exception(respons.ReasonPhrase);
                }
            }
        }
        #endregion
    }
}