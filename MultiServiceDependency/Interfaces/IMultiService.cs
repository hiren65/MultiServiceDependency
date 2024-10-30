namespace MultiServiceDependency.Interfaces
{
    public interface IMultiService
    {
        public Task< string> GetServiceName();
    }
}
