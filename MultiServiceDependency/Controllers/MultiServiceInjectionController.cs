using Microsoft.AspNetCore.Mvc;
using MultiServiceDependency.Interfaces;

namespace MultiServiceDependency.Controllers
{
    public class MultiServiceInjectionController : Controller
    {
        private readonly IMultiService multiService;
        private readonly IMultiService multiService1;
        public MultiServiceInjectionController(Func<string,IMultiService> ServiceAccessor )
        {
            multiService = ServiceAccessor("Service1");
         
            multiService1 = ServiceAccessor("Service2");
           
        }
        public async Task< IActionResult> Index()
        {
            var serviceName = await multiService.GetServiceName();
            var serviceName1 = await multiService1.GetServiceName();
            ViewBag.ServiceName = serviceName;
            ViewBag.ServiceName1 = serviceName1;
            
            return await Task.FromResult( View("Index"));
        }
    }
}
