using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        MissingCommandFactory missing_command_factory;
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands, MissingCommandFactory missing_command_factory)
        {
            this.all_commands = all_commands;
            this.missing_command_factory = missing_command_factory;
        }

        public RequestCommand get_the_command_that_can_handle(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request)) ??
                missing_command_factory();
        }
    }
}