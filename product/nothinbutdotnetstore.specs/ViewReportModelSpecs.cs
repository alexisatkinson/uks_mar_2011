using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.specs
{
    public class ViewReportModelSpecs
    {
        public class concern : Observes<ApplicationBehaviour,
                                   ViewAReportModel<IEnumerable<SomeType>>>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                model = Enumerable.Range(1, 100).Select(x => new SomeType()).ToList();
                renderer = the_dependency<RenderingGateway>();
                the_request = an<Request>();

                provide_a_basic_sut_constructor_argument<Query<IEnumerable<SomeType>>>(y =>
                {
                    y.ShouldEqual(the_request);
                    return model;
                });
            };

            Because b = () =>
                sut.process(the_request);

            It should_tell_the_renderer_to_display_the_information_retrieved_by_the_query = () =>
                renderer.received(x => x.render(model));

            static RenderingGateway renderer;
            static IEnumerable<SomeType> model;
            static Request the_request;
        }

        public class SomeType
        {
        }
    }
}