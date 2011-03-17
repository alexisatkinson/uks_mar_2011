using System;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandUrlBuilder : CommandUrlBuilder
    {
        public static implicit operator string(DefaultCommandUrlBuilder builder)
        {
            return builder.ToString();
        }

        string inputUrl;
        
        public DefaultCommandUrlBuilder(string input_url)
        {
            this.inputUrl = input_url;
        }

        public override string ToString()
        {
            return inputUrl;
        }

        public QueryBuilder include<ReportModel>(ReportModel report_model)
        {
            return new DefaultQueryBuilder<ReportModel>(inputUrl, report_model);
        }
    }

    public class DefaultQueryBuilder<ReportModel> : QueryBuilder
    {
        public DefaultQueryBuilder(string input_url, ReportModel report_model)
        {
            
        }
    }
}