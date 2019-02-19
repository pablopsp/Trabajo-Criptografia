using System.ServiceModel;
using System.ServiceModel.Web;

namespace Criptografia.WebServices
{
    [ServiceContract]
    public interface ICriptWebService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/hello",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string SayHello();
    }
}
