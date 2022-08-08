using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server {
    internal class ServerProgram {
        static void Main(string[] args) {
            Console.WriteLine("Server starting...");

            //This is the actual host service system
            ServiceHost host;
            //This represents a tcp/ip binding in the Windows network stack
            NetTcpBinding tcp = new NetTcpBinding();

            try {
                //Bind server to the implementation of DataServer
                host = new ServiceHost(typeof(DataServer));

                /*Present the publicly accessible interface to the client. 0.0.0.0 tells .net to
                accept on any interface. :8100 means this will use port 8100. DataService is a name for the
                actual service, this can be any string.*/
                host.AddServiceEndpoint(typeof(DataServerInterface), tcp, "net.tcp://0.0.0.0:8100/DataService");

                host.Open();
                Console.WriteLine("\nServer Online");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("\nServer Failed.");
                Console.ReadLine();
            }
        }
    }
}
