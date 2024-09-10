namespace MyWebServer.Results.Views.Contracts
{
    public interface IView
    {
        string ExecuteTemplate(object model, string user);
    }
}