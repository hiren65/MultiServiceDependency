using MultiServiceDependency.Interfaces;

namespace MultiServiceDependency.Models
{
    public class SecondService : IMultiService
    {
        internal string message;
        public SecondService()
        {
            message = string.Empty;
        }

        public async Task<string> GetServiceName()
        {

            message = "Service 2";

            return await Task.FromResult($"Second Service: {message}");
        }
    }
}
