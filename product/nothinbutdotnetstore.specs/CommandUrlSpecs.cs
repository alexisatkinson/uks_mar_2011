 
using System;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class CommandUrlSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(CommandUrl))]
        public class when_run   : concern
        {
            Because b = () =>
                command_url = CommandUrl.to_run<SomeApplicationBehaviour>();

            

            It should_return_the_url_for_the_application_behaviour = () =>
            {
                command_url.ShouldEqual("someapplicationbehaviour.uk");
            };

            static string command_url;
        }

        class SomeApplicationBehaviour
        {
        }
    }

    public static class CommandUrl
    {
        public static string to_run<ApplicationBehaviour>()
        {
            return typeof(ApplicationBehaviour).Name.ToLowerInvariant() + ".uk";
        }
    }
}
