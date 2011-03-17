using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class CommandUrlBuilderSpecs
    {
        public abstract class concern : Observes<CommandUrlBuilder,DefaultCommandUrlBuilder>
        {
        
        }

        [Subject(typeof(DefaultCommandUrlBuilder))]
        public class when_using_the_command_url_builder : concern
        {
            Establish c = () =>
            {
                input_url = "somebehaviour.uk";
                provide_a_basic_sut_constructor_argument(input_url);
            };

            It should_return_the_correct_url_through_implicit_string_conversion =
                () => input_url.ShouldEqual(sut.downcast_to<DefaultCommandUrlBuilder>());

            It should_return_the_correct_url_with_tostring =
                () => { sut.ToString().ShouldEqual(input_url); };

            static string input_url;
        }

        [Subject(typeof(DefaultCommandUrlBuilder))]
        public class when_using_the_command_url_builder_with_criteria : concern
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument("somebehaviour.uk");
                report_model = an<ReportModel>();
            };

            It should_build_use_the_report_model_to_return_a_query_builder = () =>
            {
                sut.include(report_model).ShouldBeOfType<QueryBuilder>();
            };

            static ReportModel report_model;
        }

        public class ReportModel
        {
        }
    }

}
