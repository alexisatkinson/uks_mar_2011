using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class QueryBuilderSpecs
    {
        public abstract class concern : Observes<QueryBuilder,
                                            DefaultQueryBuilder<AnyModel>>
        {
        
        }

        [Subject(typeof(DefaultQueryBuilder<AnyModel>))]
        public class when_observation_name : concern
        {
        
            It first_observation = () =>        
                
        }

        public class AnyModel
    {
    }
    }

    
}
