using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog product_repository;

        public ViewTheProductsInADepartment(RenderingGateway rendering_gateway, StoreCatalog product_repository)
        {
            this.product_repository = product_repository;
            this.rendering_gateway = rendering_gateway;
        }

        public void process(Request request)
        {
            rendering_gateway.render(product_repository.get_the_products_in(request.map<Department>()));
        }
    }
}