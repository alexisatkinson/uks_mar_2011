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
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                department = an<Department>();
                rendering_gateway = the_dependency<RenderingGateway>();
                the_list_of_departments = new List<Department> { new Department() };
                department_repository = the_dependency<DepartmentRepository>();
                department_repository.setup(x => x.get_sub_departments_for(department)).
                    Return(the_list_of_departments);
                department_factory = the_dependency<DepartmentFactory>();
                department_factory.setup(x => x.create_from(request)).Return(department);
            };

            Because b = () =>
                sut.process(request);

            It should_ask_the_department_factory_to_create_a_department_from_the_request = () => 
                department_factory.received(x => x.create_from(request));

            It should_get_list_of_sub_departments_from_the_departments_repository_passing_it_the_department = () => 
                department_repository.received(x => x.get_sub_departments_for(department));
            
            It should_pass_the_list_to_the_result_rendering_gateway = () =>
                rendering_gateway.received(x => x.render(the_list_of_departments));

            static Request request;
            static RenderingGateway rendering_gateway;
            static IEnumerable<Department> the_list_of_departments;
            static DepartmentRepository department_repository;
            static Department department;
            static DepartmentFactory department_factory;
        }
    }
}