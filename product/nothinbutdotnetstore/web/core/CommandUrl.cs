namespace nothinbutdotnetstore.web.core
{
    public class CommandUrl
    {
        
        public static DefaultCommandUrlBuilder to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return new DefaultCommandUrlBuilder(string.Format("{0}.uk", typeof(Behaviour).Name));
        }
    }
}