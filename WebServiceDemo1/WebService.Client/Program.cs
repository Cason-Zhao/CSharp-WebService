using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Client.TestWebService;

namespace WebService.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestWebService();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void TestWebService()
        {
            var soapHeader = new TestWebServiceSoapHeader() { Token = "TestTokenLegal" };
            string result = string.Empty;
            TestWebServiceSoapClient proxy = null;
            try
            {
                proxy = new TestWebServiceSoapClient();
                result = proxy.HelloWebService(ref soapHeader);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.Write($"Web call failed!{ex.Message}");
                throw;
            }
            finally
            {
                if (proxy != null)
                {
                    proxy.Close();
                }
            }
        }
    }
}
