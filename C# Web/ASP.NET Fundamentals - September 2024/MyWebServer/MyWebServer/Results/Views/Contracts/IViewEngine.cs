namespace MyWebServer.Results.Views.Contracts
{
    public interface IViewEngine
    {
        string RenderHtml(string content, object model, string userId);
    }
}