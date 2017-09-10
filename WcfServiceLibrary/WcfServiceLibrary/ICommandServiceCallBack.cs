using System.ServiceModel;

namespace WcfServiceLibrary
{
    public interface ICommandServiceCallBack
    {
        [OperationContract]
        void OnCallBack(string message);
    }
}