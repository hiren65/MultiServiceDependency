using MultiServiceDependency.Interfaces;

namespace MultiServiceDependency.Services
{
    public class FirstService : IMultiService
    {
        internal  string message;
        public FirstService()
        {
            message = string.Empty;
        }
        public async Task<string> GetServiceName()
        {

            message = "Service 1";

            return await Task.FromResult($"First Service: {message}");
        }
    }
}
