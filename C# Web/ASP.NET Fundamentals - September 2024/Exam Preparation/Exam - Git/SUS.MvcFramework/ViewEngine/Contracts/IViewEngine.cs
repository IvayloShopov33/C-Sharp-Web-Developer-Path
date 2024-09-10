namespace SUS.MvcFramework.ViewEngine.Contracts
{
    public interface IViewEngine
    {
        string GetHtml(string templateCode, object viewModel, string user);
    }
}
