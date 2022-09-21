using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebService.Model;

namespace WebServices
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {
        // 存储用户凭证的Soap Header信息
        // 必须保证是public和字段名必须与SoapHeader("memberName")中memberName一样
        // 否则会出现“头属性/字段 LearningHardWebService.authenticationToken 缺失或者不是公共的。”的异常
        public TestWebServiceSoapHeader AuthenticationToken;
        private const string AuthToken = "TestTokenLegal";// // 存储服务器端凭证
         
        // 定义SoapHeader传递的方向
        //SoapHeaderDirection.In;只发送SoapHeader到服务端,该值是默认值
        //SoapHeaderDirection.Out;只发送SoapHeader到客户端
        //SoapHeaderDirection.InOut;发送SoapHeader到服务端和客户端
        //SoapHeaderDirection.Fault;服务端方法异常的话，会发送异常信息到客户端
        [SoapHeader(nameof(AuthenticationToken), Direction = SoapHeaderDirection.InOut)]
        [WebMethod(EnableSession = false)]
        public string HelloWebService()
        {
            if(AuthenticationToken == null || !UserValidation.IsTokenLegal(AuthenticationToken.Token))
            {
                // 仅SoapException可被客户端捕获
                throw new SoapException("身份验证失败！", SoapException.ServerFaultCode);
            }
            return "Hello WebService! Call succeeded~";
        }
    }

    public class TestWebServiceSoapHeader: SoapHeader
    {
        // 存储用户凭证
        public string Token { get; set; }
    }
}
