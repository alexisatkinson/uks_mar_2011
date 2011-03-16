using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface DepartmentFactory
    {
        Department create_from(Request request);
    }
}