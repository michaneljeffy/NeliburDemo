using Nelibur.ServiceModel.Services;
using Nelibur.ServiceModel.Services.Default;
using Nelibur.Sword.Reflection;
using NeliburDemo.OwnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using static NeliburDemo.Ship;

namespace NeliburDemo
{
    class Program
    {
        private static WebServiceHost _service;
        private static void ConfigureService()
        {
            NeliburRestService.Configure(x =>
            {
                x.Bind<AddShipCommand, ShipProcessor>();
                x.Bind<ShipLocationQuery, ShipProcessor>();
            });

            NeliburRestService.Configure(x =>
            {
                x.Bind<CreateClientRequest, ClientProcessor>();
                x.Bind<UpdateClientRequest, ClientProcessor>();
                x.Bind<DeleteClientRequest, ClientProcessor>();
                x.Bind<GetClientRequest, ClientProcessor>();
            });
        }

        private static void SoapConfiguration()
        {
            NeliburSoapService.Configure(x =>
            {
                x.Bind<CreateClientRequest, ClientProcessor>();
                x.Bind<UpdateClientRequest, ClientProcessor>();
                x.Bind<DeleteClientRequest, ClientProcessor>();
                x.Bind<GetClientRequest, ClientProcessor>();
            });
        }

        static void Main(string[] args)
        {
            ConfigureService();

            var a = CreateCtor(typeof(Client));
            _service = new WebServiceHost(typeof(JsonServicePerCall));
            _service.Open();
            var b= a();
            Console.WriteLine("ShipTrackingService is running");
            Console.WriteLine("Press any key to exit\n");

            Console.ReadKey();
            _service.Close();
        }


        public static ObjectActivator CreateCtor(Type type)
        {
            ConstructorInfo emptyConstructor = type.GetConstructor(Type.EmptyTypes);
            var dynamicMethod = new DynamicMethod("CreateInstance", type, Type.EmptyTypes, true);
            ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Nop);
            ilGenerator.Emit(OpCodes.Newobj, emptyConstructor);
            ilGenerator.Emit(OpCodes.Ret);
            return (ObjectActivator)dynamicMethod.CreateDelegate(typeof(ObjectActivator));
        }
    }
}
