namespace nothinbutdotnetstore.web.core
{
    public interface CommandUrlBuilder
    {
        QueryBuilder include<ReportModel>(ReportModel report_model);
    }
}