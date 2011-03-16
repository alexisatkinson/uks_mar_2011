using System;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        ProductRepository product_repository;

        public ViewTheProductsInADepartment() : this(Stub.with<StubRenderingGateway>(),
                                                        Stub.with<StubProductRepository>())
        {
        }

        public ViewTheProductsInADepartment(RenderingGateway rendering_gateway,
                                               ProductRepository product_repository)
        {
            this.rendering_gateway = rendering_gateway;
            this.product_repository = product_repository;
        }

        public void process(Request request)
        {
            rendering_gateway.render(product_repository.get_the_products_for(request.map<Department>()));
        }
    }
}