using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubDepartmentFactory : DepartmentFactory
    {
        public Department create_from(Request request)
        {
            return new Department();
        }
    }
}