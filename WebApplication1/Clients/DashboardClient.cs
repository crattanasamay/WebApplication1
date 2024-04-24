using WebApplication1.Clients;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Clients
{

    public class DashboardClient : IDashboardClient
    {
        private readonly IJikanApiClient _jikanApiClient;
        public DashboardClient(IJikanApiClient jikanApiClient) {
            _jikanApiClient = jikanApiClient;
        }        




            
    }


    public interface IDashboardClient
    {

    }
}
