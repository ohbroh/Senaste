
using Agresso.Interface.CommonExtension;
using Agresso.ServerExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDE
{
    [ServerProgram("REST_2")]
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
            //            ServerAPI.Current.WriteLog("Starta rapport för GL07");
            // Save reference to IReport object
            m_Report = report;
            // Needs the ACT.SE.Common subsystem
        }

        public void Run()
        {
            // TODO: Do the coding
            ServerAPI.Current.WriteLog("1");
            ServerAPI.Current.WriteLog("2");
        }

        #endregion

        public class Class11
        {
            public string companyId { get; set; }
            public string companyName { get; set; }
        }
    }
}//using System;
 //using System.Net;
 //using System.Net.Http;
 //using System.Net.Http.Headers;
 //using System.Threading.Tasks;
 //using Agresso.Interface.CommonExtension;
 //using Agresso.ServerExtension;
 //using System.Collections.Generic;
 //using System.Linq;
 //using System.Text;

//namespace ClassLibrary1
//{
//    [ServerProgram("REST_2")]



//    public class Class1 : IServerProgram
//    {
//        private IReport m_Report;
//        static HttpClient client = new HttpClient();
//        public Class1()
//        {
//        }
//        public void End()
//        {
//            ServerAPI.Current.WriteLog("end");
//        }
//        public void Initialize(IReport report)
//        {

//            m_Report = report;
//        }
//        public void Run()
//        {
//            RunAsync().GetAwaiter().GetResult();
//        }
//        static async Task<Class11> GetProductAsync(string path)
//        {
//            Class11 product = null;
//            HttpResponseMessage response = await client.GetAsync(path);
//            if (response.IsSuccessStatusCode)
//            {
//                product = await response.Content.ReadAsAsync<Class11>();
//            }
//            return product;
//        }
//        static async Task RunAsync()
//        {
//            ServerAPI.Current.WriteLog("1");

//            // Update port # in the following line.
//            client.BaseAddress = new Uri("http://localhost/wibetest-web-api/v1/companies/AB");
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(
//            new MediaTypeWithQualityHeaderValue("application/json"));
//            try
//            {
//                ServerAPI.Current.WriteLog("2");

//                // Get the product
//                var product = await GetProductAsync("http://localhost/wibetest-web-api/v1/companies/AB");
//                ServerAPI.Current.WriteLog(product.companyId);
//                ServerAPI.Current.WriteLog(product.companyName);
//                ServerAPI.Current.WriteLog("3");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            ServerAPI.Current.WriteLog("4");       
//        }
//    }
//}
