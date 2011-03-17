using System;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class CommandUrlSpecs
    {
        public abstract class concern : Observes<CommandUrl>
        {
        }

        [Subject(typeof(CommandUrl))]
        public class when_requesting_a_url_for_a_given_command : concern
        {
            

            It it_should_return_a_command_builder =
                () => { CommandUrl.to_run<SomeBehaviour>().ShouldBeOfType<DefaultCommandUrlBuilder>(); };
        }

        [Subject(typeof(CommandUrl))]
        public class when_requesting_command_builder_a_given_command : concern
        {
            
        }

        
            


        class SomeBehaviour : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }
    }
}