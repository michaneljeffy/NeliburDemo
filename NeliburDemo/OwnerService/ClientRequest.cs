using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeliburDemo.OwnerService
{
    public  class Client
    {
        public string Email { get; set; }

        public  Guid Id { get; set; }
    }

    public class GetClientRequest: ClientRequest
    {

    }

    public class UpdateClientRequest : ClientRequest
    {

    }

    public class CreateClientRequest : ClientRequest
    {

    }

    public class DeleteClientRequest : ClientRequest
    {

    }

    public class ClientRequest : Client
    {

    }

    public class ClientResponse: Client
    {
        
    }
}
