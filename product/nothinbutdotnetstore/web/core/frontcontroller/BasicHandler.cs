using System.Web;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class BasicHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public BasicHandler() : this(Container.resolve.an<FrontController>(),
                                     Container.resolve.an<RequestFactory>())
        {
        }

        public BasicHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}