using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheProductsInADepartment>
        {
        }

        [Subject(typeof(ViewTheProductsInADepartment))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                rendering_gateway = the_dependency<RenderingGateway>();
                product_repository = the_dependency<ProductRepository>();

                the_list_of_products = new List<Product> { new Product() };
                the_department = new Department();

                request.setup(x => x.map<Department>()).Return(the_department);

                product_repository.setup(x => x.get_the_products_for(the_department)).
                    Return(the_list_of_products);
            };

            Because b = () =>
                sut.process(request);


            It should_tell_the_rendering_gateway_to_display_the_products_for_a_department = () =>
                rendering_gateway.received(x => x.render(the_list_of_products));

            static Request request;
            static ProductRepository product_repository;
            static IEnumerable<Product> the_list_of_products;
            static RenderingGateway rendering_gateway;
            static Department the_department;
        }
    }
}