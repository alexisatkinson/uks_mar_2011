using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewAReportModel<ReportModel> : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        ViewRepositoryQuery<ReportModel> query;

        public ViewAReportModel(ViewRepositoryQuery<ReportModel> query) : this(query, new WebFormRenderer())
        {
        }

        public ViewAReportModel(ViewRepositoryQuery<ReportModel> query, RenderingGateway rendering_gateway)
        {
            this.query = query;
            this.rendering_gateway = rendering_gateway;
        }

        public void process(Request request)
        {
            rendering_gateway.render(query(request));
        }
    }
}