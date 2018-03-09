using Nelibur.ServiceModel.Contracts;
using Nelibur.ServiceModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace NeliburDemo.SoapService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ShopService:ISoapService
    {
        public Message Process(Message message)
        {
            return NeliburSoapService.Process(message);
        }

        public void ProcessOneWay(Message message)
        {
            NeliburSoapService.ProcessOneWay(message);
        }
    }
}
